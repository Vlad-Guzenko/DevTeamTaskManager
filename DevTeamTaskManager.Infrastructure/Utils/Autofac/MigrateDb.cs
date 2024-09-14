using Autofac;

using Microsoft.EntityFrameworkCore;

namespace DevTeamTaskManager.Infrastructure.Utils.Autofac;

public class MigrateDb : IStartable
{
	private readonly DevTeamTaskManagerContext _context;

	public MigrateDb(DevTeamTaskManagerContext context)
	{
		_context = context;
	}

	public void Start()
	{
		_context.Database.Migrate();
	}
}