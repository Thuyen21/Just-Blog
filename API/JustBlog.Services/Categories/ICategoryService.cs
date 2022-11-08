using JustBlog.Entities.Entities;
using JustBlog.Model.Categories;
using JustBlog.Model.Common;
using JustBlog.Services.Base;

namespace JustBlog.Services.Categories;

public interface ICategoryService : IBaseService<Category, CategoryCM, CategoryVM, CategoryUM>
{
    Task<IEnumerable<Select>> GetToSelectAsync(int? page, int? pageSize);
}
