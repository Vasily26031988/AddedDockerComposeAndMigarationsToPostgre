using PromocodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Core.Abstractions.Repositories
{
	public interface IRepository<T>
		where T : BaseEntity
	{
		Task<IEnumerable<T>> GetAllAsync();

		Task<T> GetByIdAsync(Guid id);

		Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids);

		Task AddAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(T entity);
	}
}
