using System.Reflection;
using System.Threading.Tasks;

using BuildingBlocks.Domain.Persistance;

using Microsoft.EntityFrameworkCore;

namespace DevTeamTaskManager.Infrastructure;
public class DevTeamTaskManagerContext : DbContext, IUnitOfWork
{
    public DevTeamTaskManagerContext(DbContextOptions<DevTeamTaskManagerContext> options)
        : base(options)
    {
        Database.Migrate();
    }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	public async Task CommitAsync()
	{
		await SaveChangesAsync();
	}
}