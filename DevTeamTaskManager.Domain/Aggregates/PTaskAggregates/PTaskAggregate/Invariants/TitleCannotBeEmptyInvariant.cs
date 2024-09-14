using BuildingBlocks.Domain.Aggregate;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.Invariants;

internal class TitleCannotBeEmptyInvariant : IInvariant
{
	private readonly string _title;

	public string Message => $"Title should be provided";

    public TitleCannotBeEmptyInvariant(string title)
    {
        _title = title;
    }

    public bool IsViolated()
	{
		return string.IsNullOrWhiteSpace(_title);
	}
}