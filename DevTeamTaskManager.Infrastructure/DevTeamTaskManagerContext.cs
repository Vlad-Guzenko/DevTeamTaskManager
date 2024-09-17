using System.Reflection;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using BuildingBlocks.Domain.Persistance;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;
using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate;

using DevTeamTaskManager.Infrastructure.EntityConfigurations.TaskConfiguration;
using DevTeamTaskManager.Infrastructure.EntityConfigurations.TaskConfigurations;

namespace DevTeamTaskManager.Infrastructure;

public class DevTeamTaskManagerContext : DbContext, IUnitOfWork
{
	public DbSet<PTask> Tasks { get; set; }

	public DbSet<TaskComment> TaskComments { get; set; }

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
		modelBuilder.ApplyConfiguration(new TaskCommentAggregateConfiguration());
	}

	public async Task CommitAsync()
	{
		await SaveChangesAsync();
	}
}