﻿using System;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

namespace DevTeamTaskManager.Application.Dtos.Tasks.Task;

public class TaskItemDto
{
	public Guid Id { get; set; }

	public string Title { get; set; }

	public Guid ReporterId { get; set; }

	public TaskStatus Status { get; set; }
}