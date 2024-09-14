using System;

using BuildingBlocks.Domain.Aggregate;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.Invariants;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

public class PTask : EntityBase, IAggregateRoot
{
    public string Title { get; private set; }

    public Guid ReporterId { get; private set; }

    public Description Description { get; private set; }

    public TaskStatus Status { get; private set; }

    public TaskPriority Priority { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime? DueDate { get; private set; }

    protected internal PTask() { }

    private PTask(string title, Guid reporterId, string description, TaskStatus taskStatus,
        TaskPriority taskPriority, DateTime createdAt, DateTime? dueDate)
    {
        CheckInvariants(new TitleCannotBeEmptyInvariant(title),
            new ShouldHaveReporterInvariant(reporterId),
            new TaskShouldHaveStatusInvariant(taskStatus),
            new TaskShouldHavePriorityInvariant(taskPriority));

        Title = title;
        Description = new Description(description);
        Status = taskStatus;
        Priority = taskPriority;
        CreatedAt = createdAt;
        DueDate = dueDate;
    }

    public static PTask NewDraft(string title, Guid reporterId, string description, TaskStatus taskStatus,
        TaskPriority taskPriority, DateTime createdAt, DateTime? dueDate)
    {
        return new PTask(title, reporterId, description, taskStatus, taskPriority, createdAt, dueDate);
    }
}