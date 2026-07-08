using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Core.Contracts;
using Library.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services
{
    public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity>
    where TDto : class
    where TEntity : class
    {
        private readonly DataContext _ctx;


        private readonly IMapper _mapper;
        private readonly DbSet<TEntity> _dbSet;
        public GenericService(DataContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
            _dbSet = _ctx.Set<TEntity>();
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _dbSet.AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity == null ? null : _mapper.Map<TDto>(entity);
        }

        public async Task<TDto?> SaveAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _dbSet.AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto?> UpdateAsync(int id, TDto dto)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            _ctx.Update(entity);
            await _ctx.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}