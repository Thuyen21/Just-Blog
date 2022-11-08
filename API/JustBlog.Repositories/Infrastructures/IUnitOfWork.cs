using JustBlog.Repositories.Bases;
using JustBlog.Repositories.Categories;
using JustBlog.Repositories.Posts;
using JustBlog.Repositories.Tags;

namespace JustBlog.Repositories.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        PostRepository PostRepository { get; }
        CategoryRepository CategoryRepository { get; }
        TagRepository TagRepository { get; }
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task SaveAsync();
    }
}