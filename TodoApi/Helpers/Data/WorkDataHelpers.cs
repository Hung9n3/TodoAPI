using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApi.Core.Database;
using TodoApi.Core.Entities;
using TodoApi.DTOs;

namespace TodoApi.Helpers.Data
{
    public class WorkDataHelpers : BaseDataHelpers<Work,WorkDTO>
    {
        public WorkDataHelpers(TodoContext todoContext, IMapper mapper) : base(todoContext, mapper)
        {
        }
        public async Task<WorkDTO> FindByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return _mapper.Map<WorkDTO>(result);
        }
        public async Task<List<WorkDTO>> FindAll() => _mapper.Map<List<WorkDTO>>(await _dbSet.ToListAsync());
        public async Task<List<WorkDTO>> FindByUser(int userid)
        {
            var item = await _context.Calendars.Where(x => x.UserId == userid).Include(x => x.Works).FirstOrDefaultAsync();
            if (item is null) return new List<WorkDTO>();
            else return _mapper.Map<List<WorkDTO>>(item.Works.ToList());
        }
        public async Task Create(WorkDTO workDto)
        {
            var entity = MapToEntity(workDto);
            await _dbSet.AddAsync(entity);
        }
        public async Task Update(WorkDTO workDTO)
        {
            var entity = await _dbSet.FindAsync(workDTO.Id);
            if(entity is null) return;
            else _mapper.Map(workDTO,entity);
        }
        public async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null) _dbSet.Remove(entity);
            else return;
        }
    }
}
