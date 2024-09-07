namespace BuildingBlocks.Domain.Persistance;

public interface IRepository<TAggregateRoot> : IRepositoryBase<TAggregateRoot>
	where TAggregateRoot : class, IAggregateRoot
{
}