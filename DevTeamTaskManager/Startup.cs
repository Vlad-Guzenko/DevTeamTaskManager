using System.Reflection;
using System.Text.Json.Serialization;

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core;

using DevTeamTaskManager.API.Configuration;

namespace DevTeamTaskManager.API;

public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	public void ConfigureServices(IServiceCollection services)
	{
		var apiConfiguration = Configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();

		// Configure Kestrel options
		services.Configure<KestrelServerOptions>(options =>
		{
			options.Limits.MaxRequestBodySize = int.MaxValue;
		});

		// Configure controllers
		services.AddControllers()
			.AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
			});

		// Configure Swagger
		services.AddSwaggerGen(options =>
		{
			options.SwaggerDoc(apiConfiguration.ApiVersion, new OpenApiInfo
			{
				Title = apiConfiguration.ApiName,
				Version = apiConfiguration.ApiVersion
			});

			var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
			options.IncludeXmlComments(xmlPath);
		});

		// Configure CORS
		services.AddCors(options =>
		{
			options.AddDefaultPolicy(builder =>
			{
				if (apiConfiguration.CorsAllowAnyOrigin)
				{
					builder.AllowAnyOrigin()
						   .AllowAnyHeader()
						   .AllowAnyMethod();
				}
				else
				{
					builder.WithOrigins(apiConfiguration.CorsAllowOrigins)
						   .AllowAnyHeader()
						   .AllowAnyMethod();
				}
			});
		});
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});
		}

		app.UseCors();
		app.UseRouting();
		app.UseAuthorization();
		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});
	}
}