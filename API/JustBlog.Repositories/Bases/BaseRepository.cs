using JustBlog.Entities.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JustBlog.Repositories.Bases;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext context;
    protected readonly DbSet<TEntity> dbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        this.context = context;
        dbSet = context.Set<TEntity>();

    }
    public virtual async Task<IEnumerable<TEntity>> GetAsync(int? page = null, int? pageSize = null,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet.AsQueryable();
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (string includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.TrimEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }
        if (page != null)
        {
            query = pageSize != null
                ? query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value)
                : query.Skip((page.Value - 1) * 10).Take(10);
        }
        return await query.ToListAsync();
    }
    public virtual async Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        int? page = null, int? pageSize = null,
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (string includeProperty in includeProperties.Split
                 (new char[] { ',' }, StringSplitOptions.TrimEntries))
            {
                query = query.Include(includeProperty);
            }
        }


        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (page != null)
        {
            query = pageSize != null
                ? query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value)
                : query.Skip((page.Value - 1) * 10).Take(10);
        }
        return await query.Select(selector).ToListAsync();
    }
    public virtual async Task<TEntity?> GetByIdAsync(object id)
    {
        return await dbSet.FindAsync(id);
    }
    public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await dbSet.FirstOrDefaultAsync(filter);

    }
    public virtual async Task<TResult?> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> filter,
        Expression<Func<TEntity, TResult>> selector)
    {
        return await dbSet.Where(filter).Select(selector).FirstOrDefaultAsync();

    }

    public virtual async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await dbSet.SingleOrDefaultAsync(filter);

    }
    public virtual async Task<TResult?> SingleOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> filter,
        Expression<Func<TEntity, TResult>> selector)
    {
        return await dbSet.Where(filter).Select(selector).SingleOrDefaultAsync();

    }
    public virtual async Task AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }
    public virtual void Delete(object id)
    {
        TEntity? entityToDelete = dbSet.Find(id);
        if (entityToDelete != null)
        {
            dbSet.Remove(entityToDelete);
        }
    }
    public virtual void Delete(TEntity entityToDelete)
    {
        dbSet.Remove(entityToDelete);
    }
    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Update(entityToUpdate);

    }
    public virtual async Task<int> CountAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        string includeProperties = "")

    {
        IQueryable<TEntity> query = dbSet.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }


        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (string includeProperty in includeProperties.Split
                 (new char[] { ',' }, StringSplitOptions.TrimEntries))
            {
                query = query.Include(includeProperty);
            }
        }
        return await query.CountAsync();
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await dbSet.AddRangeAsync(entities);
    }

    public virtual void DeleteRange(IEnumerable<TEntity> entities)
    {
        dbSet.RemoveRange(entities);
    }

    public virtual void UpdateRange(IEnumerable<TEntity> entities)
    {
        dbSet.UpdateRange(entities);

    }

    public virtual async Task<TResult?> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> filter)
    {
        return await dbSet.Where(filter).ProjectToType<TResult>().FirstOrDefaultAsync();
    }

    public virtual async Task<IEnumerable<TResult>> GetAsync<TResult>(int? page = null, int? pageSize = null, Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (string includeProperty in includeProperties.Split
                 (new char[] { ',' }, StringSplitOptions.TrimEntries))
            {
                query = query.Include(includeProperty);
            }
        }


        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (page != null)
        {
            query = pageSize != null
                ? query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value)
                : query.Skip((page.Value - 1) * 10).Take(10);
        }
        return await query.ProjectToType<TResult>().ToListAsync();
    }

    public virtual async Task<TResult?> SingleOrDefaultAsync<TResult>(Expression<Func<TEntity, bool>> filter)
    {
        return await dbSet.Where(filter).ProjectToType<TResult>().SingleOrDefaultAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await dbSet.AnyAsync(filter);
    }
}