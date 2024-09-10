using System.Reflection;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace DevTeamTaskManager.Infrastructure;
public class DevTeamTaskManagerContext : DbContext
{
	private readonly IMediator _mediator;

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