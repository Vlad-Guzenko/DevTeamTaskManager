using System;

using BuildingBlocks.Domain.Aggregate;

using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;
using DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate.Invariants;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate;

public class TaskComment : EntityBase, IAggregateRoot
{
	public Guid TaskId { get; private set; }
	public virtual PTask Task { get; private set; }

	public string Content { get; private set; }

	public Guid AuthorId { get; private set; }

	public DateTime CreatedAt { get; private set; }

	public DateTime? UpdatedAt { get; private set; }

	protected internal TaskComment() { }

	private TaskComment(Guid taskId, string content, Guid authorId)
	{
		CheckInvariants(new ShouldHaveTaskInvariant(taskId),
			new ShouldHaveContent(content), new ShouldHaveAuthorInvariant(authorId));

		TaskId = taskId;
		Content = content;
		AuthorId = authorId;
		CreatedAt = DateTime.UtcNow;
	}

	public static TaskComment NewDraft(Guid taskId, string content, Guid authorId)
	{
		return new TaskComment(taskId, content, authorId);
	}

	public void UpdateComment(string content)
	{
		CheckInvariants(new ShouldHaveContent(content));

		Content = content;
		UpdatedAt = DateTime.UtcNow;
	}
}