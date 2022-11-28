using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Core.Entities;
using TodoApi.DataObjects;

namespace Contracts.ProcessingProviders
{
    public interface IBaseProcessingProvider<E,D> where D : BaseDTO where E : BaseEntity
    {
        Task<List<D>> FindAll(CancellationToken cancellationToken);
        Task<D?> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        Task Add(D dto);
        Task AddRange(IEnumerable<D> dtos);
        Task Update(D dto);
        Task Delete(int id);
        Task DeleteRange(IEnumerable<int> ids);
        D MapToDTO(E entity);
        List<D> MapToListDTO(List<E> entities);
        E MapToEntity(D dto);
        List<E> MapToListEntity(List<D> dtos);

    }
}
