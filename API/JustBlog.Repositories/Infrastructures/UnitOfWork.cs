using JustBlog.Entities.Context;
using JustBlog.Repositories.Bases;
using JustBlog.Repositories.Categories;
using JustBlog.Repositories.Posts;
using JustBlog.Repositories.Tags;

namespace JustBlog.Repositories.Infrastructures;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;
    public PostRepository PostRepository { get; private set; }
    public CategoryRepository CategoryRepository { get; private set; }
    public TagRepository TagRepository { get; private set; }
    public UnitOfWork(ApplicationDbContext context)
    {
        this.context = context;
        PostRepository = new PostRepository(this.context);
        CategoryRepository = new CategoryRepository(this.context);
        TagRepository = new TagRepository(this.context);
    }
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
    public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        return new BaseRepository<TEntity>(context);
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
