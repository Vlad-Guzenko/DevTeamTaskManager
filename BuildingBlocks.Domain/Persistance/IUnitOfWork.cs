using System.Threading.Tasks;

namespace BuildingBlocks.Domain.Persistance;

public interface IUnitOfWork
{
	Task CommitAsync();
}