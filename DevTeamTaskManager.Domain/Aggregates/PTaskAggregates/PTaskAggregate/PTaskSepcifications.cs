using System;

using BuildingBlocks.Domain.Persistance;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

public class PTaskSepcifications
{
	public static Specification<PTask> IsExist(Guid taskId)
	{
		return new Specification<PTask>(task => task.Id == taskId);
	}
}