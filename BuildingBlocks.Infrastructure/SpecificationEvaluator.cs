using System.Linq;

using Microsoft.EntityFrameworkCore;

using BuildingBlocks.Domain.Aggregate;
using BuildingBlocks.Domain.Persistance;

namespace BuildingBlocks.Infrastructure;

public static class SpecificationEvaluator<TAggregate> where TAggregate : class, IAggregateRoot
{
	public static IQueryable<TAggregate> GetQuery(IQueryable<TAggregate> inputQuery, ISpecification<TAggregate> specification)
	{
		var query = inputQuery;

		if (specification.Expression is not null)
		{
			query = query.Where(specification.Expression);
		}

		if (specification.OrderByExpression is not null)
		{
			if (specification.ThenByExpression is not null)
			{
				query = query.OrderBy(specification.OrderByExpression).ThenBy(specification.ThenByExpression);
			}
			else
			{
				query = query.OrderBy(specification.OrderByExpression);
			}
		}
		else if (specification.OrderByDescendingExpression is not null)
		{
			if (specification.ThenByExpression is not null)
			{
				query = query.OrderByDescending(specification.OrderByDescendingExpression).ThenBy(specification.ThenByExpression);
			}
			else
			{
				query = query.OrderByDescending(specification.OrderByDescendingExpression);
			}
		}

		query = specification.IncludesExpression.Aggregate(query, (current, include) => current.Include(include));
		return query;
	}
}
