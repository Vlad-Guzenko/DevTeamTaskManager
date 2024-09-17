using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using BuildingBlocks.Domain.Aggregate;

namespace BuildingBlocks.Domain.Persistance;

public interface IRepositoryBase<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
	TAggregateRoot Add(TAggregateRoot aggregate);

	void Remove(TAggregateRoot aggregate);

	Task<TAggregateRoot> GetAsync(Guid id, CancellationToken cancellationToken = default);

	Task<List<TAggregateRoot>> ListAsync(CancellationToken cancellationToken = default);

	Task<bool> AnyAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken = default);
}