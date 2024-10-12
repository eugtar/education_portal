using System.Linq.Expressions;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DatabaseContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DatabaseContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(ICollection<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToArrayAsync();
    }

    public async Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task<ICollection<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public Task RemoveAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public Task RemoveRangeAsync(ICollection<T> entities)
    {
        _dbSet.RemoveRange(entities);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        return Task.CompletedTask;
    }
}
