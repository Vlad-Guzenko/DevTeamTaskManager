namespace BuildingBlocks.Domain.Aggregate;

public interface IInvariant
{
	string Message { get; }

	bool IsViolated();
}