using JustBlog.Entities.Entities;
using JustBlog.Model.Common;
using JustBlog.Model.Tags;
using JustBlog.Repositories.Infrastructures;
using JustBlog.Services.Base;

namespace JustBlog.Services.Tags;

public class TagService : BaseService<Tag, TagCM, TagVM, TagUM>, ITagService
{
    public TagService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }
    public override async Task DeleteAsync(object id)
    {
        Repositories.Bases.IBaseRepository<PostTag> postTagRepository = unitOfWork.GetRepository<PostTag>();
        IEnumerable<PostTag> postTag = await postTagRepository.GetAsync(filter: pt => pt.TagId == (Guid)id);
        unitOfWork.GetRepository<PostTag>().DeleteRange(postTag);
        await base.DeleteAsync(id);
    }
    public async Task<IEnumerable<Select>> GetToSelectAsync(int? page, int? pageSize)
    {
        return await unitOfWork.TagRepository.GetAsync<Select>(pageSize: pageSize, page: page);
    }
}
