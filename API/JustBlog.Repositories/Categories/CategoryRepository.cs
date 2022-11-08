using JustBlog.Entities.Context;
using JustBlog.Entities.Entities;
using JustBlog.Repositories.Bases;

namespace JustBlog.Repositories.Categories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
