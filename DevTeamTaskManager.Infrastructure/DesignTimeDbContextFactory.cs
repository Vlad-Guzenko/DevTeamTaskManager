using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DevTeamTaskManager.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DevTeamTaskManagerContext>
{
	public DevTeamTaskManagerContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(@"C:\Users\workv\Source\Repos\devteamtaskmanager\DevTeamTaskManager")
			.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
			.Build();


		var optionsBuilder = new DbContextOptionsBuilder<DevTeamTaskManagerContext>();
		optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

		return new DevTeamTaskManagerContext(optionsBuilder.Options);

	}
}