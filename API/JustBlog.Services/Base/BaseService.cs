using JustBlog.Repositories.Infrastructures;
using Mapster;
using System.Linq.Expressions;

namespace JustBlog.Services.Base
{
    public class BaseService<TEntity, TEntityCM, TEntityVM, TEntityUM> : IBaseService<TEntity, TEntityCM, TEntityVM, TEntityUM>
        where TEntity : class
        where TEntityCM : class
        where TEntityVM : class
        where TEntityUM : class
    {
        protected readonly IUnitOfWork unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public virtual async Task AddAsync(TEntityCM entity)
        {
            TEntity entityToAdd = entity.Adapt<TEntity>();
            await unitOfWork.GetRepository<TEntity>().AddAsync(entityToAdd);
            await unitOfWork.SaveAsync();
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntityCM> entities)
        {
            IEnumerable<TEntity> entitiesToAdd = entities.Select(e => e.Adapt<TEntity>());
            await unitOfWork.GetRepository<TEntity>().AddRangeAsync(entitiesToAdd);
            await unitOfWork.SaveAsync();
        }

        public virtual async Task DeleteAsync(TEntityVM entityToDelete)
        {
            unitOfWork.GetRepository<TEntity>().Delete(entityToDelete.Adapt<TEntity>());
            await unitOfWork.SaveAsync();
        }

        public virtual async Task DeleteAsync(object id)
        {
            unitOfWork.GetRepository<TEntity>().Delete(id);
            await unitOfWork.SaveAsync();
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<TEntityVM> entities)
        {
            unitOfWork.GetRepository<TEntity>().DeleteRange(entities.Select(e => e.Adapt<TEntity>()));
            await unitOfWork.SaveAsync();
        }

        public virtual async Task<TEntityVM?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await unitOfWork.GetRepository<TEntity>().FirstOrDefaultAsync<TEntityVM>(filter);
        }

        public virtual async Task<IEnumerable<TEntityVM>> GetAsync(int? page = null, int? pageSize = null, Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string includeProperties = "")
        {
            return await unitOfWork.GetRepository<TEntity>().GetAsync<TEntityVM>(page, pageSize, filter, orderBy, includeProperties);
        }

        public virtual async Task UpdateAsync(TEntityUM entityToUpdate)
        {
            //var id = entityToUpdate.GetType().GetProperty("Id").GetValue(entityToUpdate);
            //var entity = await unitOfWork.GetRepository<TEntity>().GetByIdAsync(id);
            //if(entity == null)
            //{
            //    throw new ArgumentException("Entity not found");
            //}
            //entity = entityToUpdate.Adapt(entity);
            unitOfWork.GetRepository<TEntity>().Update(entityToUpdate.Adapt<TEntity>());
            await unitOfWork.SaveAsync();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntityUM> entities)
        {
            unitOfWork.GetRepository<TEntity>().UpdateRange(entities.Select(e => e.Adapt<TEntity>()));
            await unitOfWork.SaveAsync();
        }
    }
}
