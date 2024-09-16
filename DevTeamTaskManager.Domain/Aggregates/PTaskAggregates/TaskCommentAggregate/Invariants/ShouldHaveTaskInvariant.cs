using System;

using BuildingBlocks.Domain.Aggregate;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate.Invariants;

public class ShouldHaveTaskInvariant : IInvariant
{
	private readonly Guid _taskId;

	public string Message => "Task should be provided";

	public ShouldHaveTaskInvariant(Guid taskId)
	{
		_taskId = taskId;
	}

	public bool IsViolated()
	{
		return _taskId.Equals(Guid.Empty);
	}
}