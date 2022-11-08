using System.Linq.Expressions;

namespace JustBlog.Services.Base
{
    public interface IBaseService<TEntity, TEntityCM, TEntityVM, TEntityUM>
        where TEntity : class
        where TEntityCM : class
        where TEntityVM : class
         where TEntityUM : class
    {
        Task AddAsync(TEntityCM entity);
        Task AddRangeAsync(IEnumerable<TEntityCM> entities);
        Task DeleteAsync(TEntityVM entityToDelete);
        Task DeleteAsync(object id);
        Task DeleteRangeAsync(IEnumerable<TEntityVM> entities);
        Task<IEnumerable<TEntityVM>> GetAsync(int? page = null,
            int? pageSize = null, Expression<Func<TEntity, bool>>?
            filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");
        Task<TEntityVM?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);
        Task UpdateAsync(TEntityUM entityToUpdate);
        Task UpdateRangeAsync(IEnumerable<TEntityUM> entities);
    }
}