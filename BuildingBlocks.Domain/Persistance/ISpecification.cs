using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using BuildingBlocks.Domain.Aggregate;

namespace BuildingBlocks.Domain.Persistance;

public interface ISpecification<TAggregate> where TAggregate : class, IAggregateRoot
{
	Expression<Func<TAggregate, bool>> Expression { get; }

	Expression<Func<TAggregate, object>> OrderByExpression { get; }

	Expression<Func<TAggregate, object>> ThenByExpression { get; }

	Expression<Func<TAggregate, object>> OrderByDescendingExpression { get; }

	List<Expression<Func<TAggregate, object>>> IncludesExpression { get; }

	bool IsSatisfiedBy(TAggregate aggregate);
}