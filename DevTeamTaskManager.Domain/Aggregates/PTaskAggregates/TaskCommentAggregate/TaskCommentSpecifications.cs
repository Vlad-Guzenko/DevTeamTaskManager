using System;

using BuildingBlocks.Domain.Persistance;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate;

public class TaskCommentSpecifications
{
	public static Specification<TaskComment> TaskComments(Guid taskId)
	{
		return new Specification<TaskComment>(taskComment => taskComment.TaskId == taskId);
	}
}