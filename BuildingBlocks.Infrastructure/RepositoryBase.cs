using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using BuildingBlocks.Domain.Aggregate;
using BuildingBlocks.Domain.Persistance;
using System.Collections.Generic;

namespace BuildingBlocks.Infrastructure;

public abstract class RepositoryBase<TAggregateRoot> : IRepositoryBase<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
	protected readonly DbContext DbContext;

    public RepositoryBase(DbContext context)
    {
        DbContext = context;
    }

    public TAggregateRoot Add(TAggregateRoot aggregate)
    {
        DbContext.Set<TAggregateRoot>().Add(aggregate);

        return aggregate;
    }

    public TAggregateRoot Update(TAggregateRoot aggregate)
    {
        DbContext.Set<TAggregateRoot>().Update(aggregate);

        return aggregate;
    }

    public void Remove(TAggregateRoot aggregate)
    {
        DbContext.Set<TAggregateRoot>().Remove(aggregate);
    }

	public void Remove<TAggregate>(TAggregate aggregate) where TAggregate : EntityBase
	{
		DbContext.Set<TAggregate>().Remove(aggregate);
	}

	public async Task<TAggregateRoot> GetAsync(Guid id, CancellationToken cancellationToken = default)
	{
		return await DbContext.Set<TAggregateRoot>().FindAsync(id, cancellationToken);
	}

	public async Task<TAggregateRoot> GetAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken = default)
	{
		return await SpecificationEvaluator<TAggregateRoot>.GetQuery(DbContext.Set<TAggregateRoot>(), specification).FirstOrDefaultAsync(specification, cancellationToken);
	}

	public async Task<List<TAggregateRoot>> ListAsync(CancellationToken cancellationToken = default)
	{
		return await DbContext.Set<TAggregateRoot>().ToListAsync(cancellationToken);
	}

	public async Task<bool> AnyAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken = default)
	{
		return await SpecificationEvaluator<TAggregateRoot>.GetQuery(DbContext.Set<TAggregateRoot>(), specification).AnyAsync(specification, cancellationToken);
	}
}