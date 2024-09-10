using System;

using BuildingBlocks.Domain.Aggregate;

namespace BuildingBlocks.Domain.Exceptions;

public class DomainException : Exception
{
    public readonly IInvariant _invariant;

    public DomainException(IInvariant invariant)
        : base(invariant.Message)
    {
        _invariant = invariant;
    }

    public override string ToString()
    {
        return $"{_invariant.GetType().FullName}: {_invariant.Message}";
    }
}