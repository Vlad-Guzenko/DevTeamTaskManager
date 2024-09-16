using System;

using BuildingBlocks.Domain.Aggregate;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate.Invariants;

public class ShouldHaveAuthorInvariant : IInvariant
{
	private readonly Guid _authorId;

	public string Message => "Author should be provided";

	public ShouldHaveAuthorInvariant(Guid authorId)
	{
		_authorId = authorId;
	}

	public bool IsViolated()
	{
		return _authorId.Equals(Guid.Empty);
	}
}