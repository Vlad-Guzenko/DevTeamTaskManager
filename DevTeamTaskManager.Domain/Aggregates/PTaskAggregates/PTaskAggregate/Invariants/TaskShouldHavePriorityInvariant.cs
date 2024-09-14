using System;

using BuildingBlocks.Domain.Aggregate;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.Invariants;

internal class TaskShouldHavePriorityInvariant : IInvariant
{
	private TaskPriority _taskPriority;

	public string Message => $"Wrong task priority";

    public TaskShouldHavePriorityInvariant(	TaskPriority taskPriority)
    {
		_taskPriority = taskPriority;
    }

    public bool IsViolated()
	{
		return !Enum.IsDefined(_taskPriority);
	}
}