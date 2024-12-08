using System.Linq.Expressions;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DatabaseContext _context;
    private readonly DbSet<T> _entities;

    public GenericRepository(DatabaseContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _entities.AddRangeAsync(entities);
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await _entities.Where(predicate).ToArrayAsync();
    }

    public async Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate)
    {
        return await _entities.FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
    {
        return await _entities.AnyAsync(predicate);
    }

    public Task RemoveAsync(T entity)
    {
        _entities.Remove(entity);
        return Task.CompletedTask;
    }

    public Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        _entities.RemoveRange(entities);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        return Task.CompletedTask;
    }

    public IQueryable<T> AsQueryable()
    {
        return _entities.AsQueryable();
    }
}