using System.Threading.Tasks;

namespace NurBNB.Reservas.SharedKernel.Core;

public interface IRepository<T, in TId> where T : AggregateRoot
{
	Task<T?> FindByIdAsync(TId id);

	Task CreateAsync(T obj);

}
