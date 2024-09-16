using BuildingBlocks.Domain.Aggregate;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.TaskCommentAggregate.Invariants;

public class ShouldHaveContent : IInvariant
{
	private readonly string _content;

	public string Message => $"Content should be provided";

	public ShouldHaveContent(string content)
	{
		_content = content;
	}

	public bool IsViolated()
	{
		return string.IsNullOrWhiteSpace(_content);
	}
}