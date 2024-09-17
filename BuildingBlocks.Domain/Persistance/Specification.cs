using System;
using System.Linq.Expressions;
using System.Collections.Generic;

using BuildingBlocks.Domain.Aggregate;

namespace BuildingBlocks.Domain.Persistance;

public sealed class Specification<TAggregate> : ISpecification<TAggregate>
	where TAggregate : class, IAggregateRoot
{
	public Expression<Func<TAggregate, bool>> Expression { get; }

	public Expression<Func<TAggregate, object>> OrderByExpression { get; private set; }

	public Expression<Func<TAggregate, object>> ThenByExpression { get; private set; }

	public Expression<Func<TAggregate, object>> OrderByDescendingExpression { get; private set; }

	public List<Expression<Func<TAggregate, object>>> IncludesExpression { get; } = new List<Expression<Func<TAggregate, object>>>();

	public Specification(Expression<Func<TAggregate, bool>> expression)
	{
		Expression = expression;
		if (expression == null) throw new ArgumentNullException(nameof(expression));
	}

	public bool IsSatisfiedBy(TAggregate aggregate)
	{
		return Expression.Compile().Invoke(aggregate);
	}

	public Specification<TAggregate> AddInclude(Expression<Func<TAggregate, object>> includeExpression)
	{
		IncludesExpression.Add(includeExpression);

		return this;
	}

	public Specification<TAggregate> AddOrderBy(Expression<Func<TAggregate, object>> orderByExpression)
	{
		OrderByExpression = orderByExpression;

		return this;
	}

	public Specification<TAggregate> AddThenBy(Expression<Func<TAggregate, object>> thenByExpression)
	{
		ThenByExpression = thenByExpression;

		return this;
	}

	public Specification<TAggregate> AddOrderByDescending(Expression<Func<TAggregate, object>> orderByDescendingExpression)
	{
		OrderByDescendingExpression = orderByDescendingExpression;

		return this;
	}


	public static implicit operator Expression<Func<TAggregate, bool>>(Specification<TAggregate> spec)
		=> spec.Expression;

	public static bool operator false(Specification<TAggregate> spec)
	{
		return false;
	}

	public static bool operator true(Specification<TAggregate> spec)
	{
		return false;
	}

	public static Specification<TAggregate> operator &(Specification<TAggregate> spec1, Specification<TAggregate> spec2)
			=> new Specification<TAggregate>(spec1.Expression.And(spec2.Expression));

	public static Specification<TAggregate> operator |(Specification<TAggregate> spec1, Specification<TAggregate> spec2)
			=> new Specification<TAggregate>(spec1.Expression.Or(spec2.Expression));

	public static Specification<TAggregate> operator !(Specification<TAggregate> spec)
		=> new Specification<TAggregate>(spec.Expression.Not());

	//public IQueryable<T> Apply(IQueryable<T> query)
	//        => query.Where(Expression);
}