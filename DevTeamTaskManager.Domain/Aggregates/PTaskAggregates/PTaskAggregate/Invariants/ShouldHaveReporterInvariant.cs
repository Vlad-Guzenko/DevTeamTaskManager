using System;

using BuildingBlocks.Domain.Aggregate;

namespace DevTeamTaskManager.Domain.Aggregates.PTaskAggregates.PTaskAggregate.Invariants;

internal class ShouldHaveReporterInvariant : IInvariant
{
	private readonly Guid _reporterId;

	public string Message => "Reporter should be provided";

	public ShouldHaveReporterInvariant(Guid reporterId)
	{
		_reporterId = reporterId;
	}

	public bool IsViolated()
	{
		return _reporterId.Equals(Guid.Empty);
	}
}