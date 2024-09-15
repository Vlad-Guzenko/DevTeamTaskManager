using System;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

namespace DevTeamTaskManager.Application.Dtos.Tasks.Task;

public class TaskItemDto
{
	public string Title { get; private set; }

	public Guid ReporterId { get; private set; }

	public TaskStatus Status { get; private set; }
}