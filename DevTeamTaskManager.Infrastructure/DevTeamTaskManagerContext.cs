using System.Reflection;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using BuildingBlocks.Domain.Persistance;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;
using DevTeamTaskManager.Infrastructure.EntityConfigurations.TaskConfiguration;

namespace DevTeamTaskManager.Infrastructure;

public class DevTeamTaskManagerContext : DbContext, IUnitOfWork
{
	public DbSet<PTask> Tasks { get; set; }

    private DevTeamTaskManagerContext() {}

    public DevTeamTaskManagerContext(DbContextOptions<DevTeamTaskManagerContext> options)
        : base(options)
    {
        Database.Migrate();
    }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		modelBuilder.ApplyConfiguration(new TaskAggregateConfiguration());
	}

	public async Task CommitAsync()
	{
		await SaveChangesAsync();
	}
}