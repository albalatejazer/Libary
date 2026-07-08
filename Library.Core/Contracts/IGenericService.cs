using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Contracts
{
    public interface IGenericService<TDto, TEntity>
        where TDto : class
        where TEntity : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(int id);
        Task<TDto?> SaveAsync(TDto dto);
        Task<TDto?> UpdateAsync(int id, TDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
