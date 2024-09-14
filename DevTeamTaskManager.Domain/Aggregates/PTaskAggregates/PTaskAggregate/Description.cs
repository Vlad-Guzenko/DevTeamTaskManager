using BuildingBlocks.Domain.Aggregate;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate;

public class Description : ValueObject
{
    public string Content { get; private set; }

    public Description() { }

    public Description(string content)
    {
        Content = content;
    }
}