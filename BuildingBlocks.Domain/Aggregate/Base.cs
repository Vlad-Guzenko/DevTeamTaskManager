using BuildingBlocks.Domain.Exceptions;

namespace BuildingBlocks.Domain.Aggregate;

public abstract class Base
{
	protected void CheckInvariants(params IInvariant[] invariants)
	{
		foreach (var invariant in invariants)
		{
			if (invariant.IsViolated())
			{
				throw new DomainException(invariant);
			}
		}
	}
}