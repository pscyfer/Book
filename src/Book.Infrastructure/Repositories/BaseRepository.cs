using Book.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Book.Infrastructure;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context;
    private readonly DbSet<TEntity> _db;

    protected BaseRepository(DataContext context)
    {
        _context = context;
        _db = context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _db.ToListAsync();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _db.Where(predicate).ToListAsync();
    }

    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await _db.Where(predicate).FirstOrDefaultAsync();

        if (entity == null) throw new ResourceNotFoundException(typeof(TEntity));

        return await _db.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = (await _db.AddAsync(entity)).Entity;
        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _db.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var result = _db.Remove(entity).Entity;
        await _context.SaveChangesAsync();

        return result;
    }

    public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _db.AnyAsync(predicate);
    }

    public virtual async Task<int> TotalCount()
    {
        return await _db.CountAsync();
    }
}
