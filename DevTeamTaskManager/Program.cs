using System.Text.Json.Serialization;

using AutoMapper;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

using DevTeamTaskManager.API.Configuration;
using DevTeamTaskManager.API.Utils.Extentions;

using DevTeamTaskManager.Infrastructure;
using DevTeamTaskManager.Infrastructure.Utils.Autofac;

var builder = WebApplication.CreateBuilder(args);

var configuration = GetConfiguration(builder.Environment.EnvironmentName);

var apiConfiguration = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
	containerBuilder.RegisterModule(new InfrastructureModule(configuration));
});

builder.Services.AddDbContext<DevTeamTaskManagerContext>(options =>
{
	options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});

var mapper = new Mapper(new MapperConfiguration(cfg =>
{
}));
builder.Services.AddSingleton<IMapper>(mapper);

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<KestrelServerOptions>(options =>
{
	options.Limits.MaxRequestBodySize = int.MaxValue;
});

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger(configuration);

builder.Services.AddApiCors(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.DisplayRequestDuration();
		options.SwaggerEndpoint($"{apiConfiguration.ApiBaseUrl}/swagger/v1/swagger.json", apiConfiguration.ApiName);

		options.OAuthAppName(apiConfiguration.ApiName);
		options.OAuthUsePkce();
	});
}

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

IConfiguration GetConfiguration(string environment)
{
	var builder = new ConfigurationBuilder()
		.SetBasePath(Directory.GetCurrentDirectory())
		.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
		.AddJsonFile($"appsettings.{environment}.json", optional: false, reloadOnChange: true)
		.AddEnvironmentVariables();

	var config = builder.Build();

	return builder.Build();
}