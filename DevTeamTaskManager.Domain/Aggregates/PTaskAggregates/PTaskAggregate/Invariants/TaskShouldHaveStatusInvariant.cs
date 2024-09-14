using System;

using BuildingBlocks.Domain.Aggregate;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.Invariants;

internal class TaskShouldHaveStatusInvariant : IInvariant
{
	private TaskStatus _taskStatus;

	public string Message => $"Wrong task status";

	public TaskShouldHaveStatusInvariant(TaskStatus taskStatus)
	{
		_taskStatus = taskStatus;
	}

	public bool IsViolated()
	{
		return !Enum.IsDefined(_taskStatus);
	}
}