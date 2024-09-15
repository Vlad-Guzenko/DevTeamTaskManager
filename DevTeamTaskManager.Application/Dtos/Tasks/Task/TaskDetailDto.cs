using System;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

namespace DevTeamTaskManager.Application.Dtos.Tasks.Task;

public class TaskDetailDto
{
	public string Title { get; set; }

	public Guid ReporterId { get; set; }

	public TaskDescriptionDetailDto Description { get; set; }

	public TaskStatus Status { get; set; }

	public TaskPriority Priority { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime? DueDate { get; set; }
}

public class TaskDescriptionDetailDto
{
	public string Content { get; set; }
}