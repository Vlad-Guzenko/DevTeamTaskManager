using System;

namespace BuildingBlocks.Domain.Aggregate;

public abstract class EntityBase : Base
{
	public Guid Id { get; protected set; }
}