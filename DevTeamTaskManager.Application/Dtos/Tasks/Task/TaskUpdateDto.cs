using System;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

namespace DevTeamTaskManager.Application.Dtos.Tasks.Task;

public class TaskUpdateDto
{
	public Guid Id { get; set; }

	public string Title { get; set; }

	public Guid ReporterId { get; set; }

	public string Description { get; set; }

	public TaskStatus Status { get; set; }

	public TaskPriority Priority { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime? DueDate { get; set; }
}