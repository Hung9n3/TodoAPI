using AutoMapper;
using Contracts.DataProviders;
using Contracts.ProcessingProviders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Core.Entities;
using TodoApi.DataObjects;

namespace TodoApi.ProcessingProvider
{
    public class BaseProcessingProvider<E, D> : IBaseProcessingProvider<E, D> where E : BaseEntity where D : BaseDTO
    {
        protected IBaseDataProvider<E> _dataProvider;
        protected IMapper _mapper;
        public BaseProcessingProvider(IBaseDataProvider<E> dataProvider, IMapper mapper)
        {
            _dataProvider = dataProvider;
            _mapper = mapper;
        }
        public async Task Add(D dto)
        {
            var entity = MapToEntity(dto);
            _dataProvider.Add(entity);
           await _dataProvider.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<D> dtos)
        {
            var list = MapToListEntity(dtos.ToList());
            _dataProvider.AddRange(list);
            await _dataProvider.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _dataProvider.FindByIdAsync(id);
            if(entity is not null)
                _dataProvider.Delete(entity);
            await _dataProvider.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<int> ids)
        {
            var list = await _dataProvider.FindByListIdAsync(ids.ToList());
            if (list is not null || list.Count > 0) _dataProvider.DeleteRange(list);
            await _dataProvider.SaveChangesAsync();
        }

        public async Task<List<D>> FindAll(CancellationToken cancellationToken)
        { 
            return MapToListDTO(await _dataProvider.FindAll().ToListAsync(cancellationToken));
        }

        public async Task<D?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return MapToDTO( await _dataProvider.FindByIdAsync(id));
        }

        public D MapToDTO(E entity)
        {
            return _mapper.Map<D>(entity);
        }
        public List<D> MapToListDTO(List<E> entities)
        {
            return _mapper.Map<List<D>>(entities);
        }
        public E MapToEntity(D dto)
        {
            return _mapper.Map<E>(dto);
        }
        public List<E> MapToListEntity(List<D> dtos)
        {
            return _mapper.Map<List<E>>(dtos);
        }
        public async Task Update(D dto)
        {
            var entity = await _dataProvider.FindByIdAsync(dto.Id);
            _mapper.Map(dto, entity);
            await _dataProvider.SaveChangesAsync();
        }
    }
}
