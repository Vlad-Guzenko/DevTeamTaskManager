using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using BuildingBlocks.Domain.Aggregate;

namespace BuildingBlocks.Domain.Persistance;

public interface IRepositoryBase<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
	TAggregateRoot Add(TAggregateRoot aggregate);

	TAggregateRoot Update(TAggregateRoot aggregate);

	void Remove(TAggregateRoot aggregate);

	void Remove<TAggregate>(TAggregate aggregate) where TAggregate : EntityBase;

	Task<TAggregateRoot> GetAsync(Guid id, CancellationToken cancellationToken = default);

	Task<TAggregate> GetAsync<TAggregate>(Guid id, CancellationToken cancellationToken = default) where TAggregate : class, TAggregateRoot;

	Task<TAggregateRoot> GetAsync(ISpecification<TAggregateRoot> specification, CancellationToken cancellationToken = default);

	Task<TAggregate> GetAsync<TAggregate>(Specification<TAggregateRoot> specification, CancellationToken cancellationToken = default) where TAggregate : class, TAggregateRoot;

	Task<TAggregateRoot> GetAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken = default);

	Task<List<TAggregateRoot>> ListAsync(CancellationToken cancellationToken = default);

	Task<List<TAggregateRoot>> ListAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken = default);

	Task<List<TAggregate>> ListAsync<TAggregate>(Specification<TAggregateRoot> specification, CancellationToken cancellationToken = default) where TAggregate : class, TAggregateRoot;

	Task<bool> AnyAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken = default);

	Task<bool> AnyAsync<TAggregate>(Specification<TAggregate> specification, CancellationToken cancellationToken = default) where TAggregate : class, TAggregateRoot;
}