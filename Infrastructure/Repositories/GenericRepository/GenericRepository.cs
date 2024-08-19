using System.Linq.Expressions;
using Application.Interfaces;
using Domain.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DatabaseContext _context;
    private readonly DbSet<T> _entities;

    public GenericRepository(DatabaseContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public ICollection<T> GetAll()
    {
        return [.. _entities];
    }

    public T? GetById(int id)
    {
        return _context.Find<T>(id);
    }

    public ICollection<T> Find(Expression<Func<T, bool>> predicate)
    {
        return [.. _entities.Where(predicate)];
    }

    public void Add(T entity)
    {
        _entities.Add(entity);
    }

    public void AddRange(T entities)
    {
        _entities.AddRange(entities);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Remove(T entity)
    {
        _entities.Remove(entity);
    }

    public void RemoveRange(T entities)
    {
        _entities.RemoveRange(entities);
    }
}
