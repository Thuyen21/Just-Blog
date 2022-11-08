using JustBlog.Entities.Entities;
using JustBlog.Model.Categories;
using JustBlog.Model.Common;
using JustBlog.Repositories.Infrastructures;
using JustBlog.Services.Base;

namespace JustBlog.Services.Categories;

public class CategoryService : BaseService<Category, CategoryCM, CategoryVM, CategoryUM>, ICategoryService
{
    public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }
    public override async Task DeleteAsync(object id)
    {
        if (await unitOfWork.PostRepository.AnyAsync(c => c.CategoryId == (Guid)id))
        {
            throw new ArgumentException("Category is using");
        }
        await base.DeleteAsync(id);
    }

    public async Task<IEnumerable<Select>> GetToSelectAsync(int? page, int? pageSize)
    {
        return await unitOfWork.CategoryRepository.GetAsync<Select>(pageSize: pageSize, page: page);
    }
}
