using System;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

namespace DevTeamTaskManager.Application.Dtos.Tasks.Task;

public class TaskUpdateDto
{
	public Guid Id { get; set; }

	public string Title { get; private set; }

	public Guid ReporterId { get; private set; }

	public DescriptionUpdateDto Description { get; private set; }

	public TaskStatus Status { get; private set; }

	public TaskPriority Priority { get; private set; }

	public DateTime CreatedAt { get; private set; }

	public DateTime? DueDate { get; private set; }
}

public class DescriptionUpdateDto
{
	public string Content { get; set; }
}