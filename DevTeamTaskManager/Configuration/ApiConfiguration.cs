namespace DevTeamTaskManager.API.Configuration;

public class ApiConfiguration
{
	public string ApiName { get; set; }

    public string ApiVersion { get; set; }

	public string ApiBaseUrl { get; set; }

	public bool RequireHttpsMetadata { get; set; }

	public bool CorsAllowAnyOrigin { get; set; }

	public string[] CorsAllowOrigins { get; set; }
}