using System.Reflection;

using Microsoft.OpenApi.Models;

using DevTeamTaskManager.API.Configuration;

namespace DevTeamTaskManager.API.Utils.Extentions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
	{
		var apiConfiguration = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();

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

		return services;
	}


	public static IServiceCollection AddApiCors(this IServiceCollection services, IConfiguration configuration)
	{
		var apiConfiguration = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();

		services.AddCors(options =>
		{
			options.AddDefaultPolicy(
				builder =>
				{
					if (apiConfiguration.CorsAllowAnyOrigin)
					{
						builder.AllowAnyOrigin()
							   .AllowAnyHeader()
							   .AllowAnyMethod();
						return;
					}

					builder.WithOrigins(apiConfiguration.CorsAllowOrigins)
						   .AllowAnyHeader()
						   .AllowAnyMethod();
				});
		});

		return services;
	}
}