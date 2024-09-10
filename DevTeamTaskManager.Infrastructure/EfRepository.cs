using BuildingBlocks.Domain.Aggregate;
using BuildingBlocks.Domain.Persistance;

using BuildingBlocks.Infrastructure;

namespace DevTeamTaskManager.Infrastructure;

public class EfRepository<TAggregate> : RepositoryBase<TAggregate>, IRepository<TAggregate> 
	where TAggregate : class, IAggregateRoot
{
	public EfRepository(DevTeamTaskManagerContext dbContext) : base()
	{
	}
}