using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TodoApi.Core.Database;
using TodoApi.Core.Entities;
using TodoApi.DataObjects;

namespace TodoApi.Helpers.Data
{
    public class BaseDataHelpers<T,A> where T : BaseEntity where A : BaseDTO
    {
        protected readonly TodoContext _context;
        protected readonly IMapper _mapper;
        protected readonly DbSet<T> _dbSet;
        public BaseDataHelpers(TodoContext todoContext, IMapper mapper)
        {
            _context = todoContext;
            _dbSet = _context.Set<T>();
            _mapper = mapper;
        }
        public async Task<bool> IsExist(int id)
        {
            var Id = await _dbSet.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);
            if (Id != 0) return true;
            else return false;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public A MapToDTO(T source) => _mapper.Map<A>(source);
        public T MapToEntity(A source) => _mapper.Map<T>(source);
    }
}
