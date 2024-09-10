using System.Reflection;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace DevTeamTaskManager.Infrastructure;
public class DevTeamTaskManagerContext : DbContext
{
	private readonly IMediator _mediator;

    public DevTeamTaskManagerContext(DbContextOptions<DevTeamTaskManagerContext> options,  IMediator mediator)
        : base(options)
    {
        Database.Migrate();

        _mediator = mediator;
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