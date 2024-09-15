using System;

using BuildingBlocks.Domain.Persistance;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

public class PTaskSepcifications
{
	public static Specification<PTask> IsExist(Guid id)
	{
		return new Specification<PTask>(task => task.Id == id);
	}
}