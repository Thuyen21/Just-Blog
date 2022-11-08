using JustBlog.Entities.Entities;
using JustBlog.Model.Posts;
using JustBlog.Repositories.Infrastructures;
using JustBlog.Services.Base;

namespace JustBlog.Services.Posts;

public class PostService : BaseService<Post, PostCM, PostVM, PostUM>, IPostService
{
    public PostService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<IEnumerable<PostVM>> CategoryNameAsync(string? name)
    {
        return await unitOfWork.PostRepository.GetAsync<PostVM>(filter: c => c.Category.Name == name);
    }

    public override async Task DeleteAsync(object id)
    {
        Repositories.Bases.IBaseRepository<PostTag> postTagRepository = unitOfWork.GetRepository<PostTag>();
        IEnumerable<PostTag> postTag = await postTagRepository.GetAsync(filter: pt => pt.PostId == (Guid)id);
        unitOfWork.GetRepository<PostTag>().DeleteRange(postTag);
        await base.DeleteAsync(id);
    }

    public async Task<IEnumerable<PostVM>> LatestAsync(int? page, int? pageSize)
    {
        return await unitOfWork.PostRepository.GetAsync<PostVM>(orderBy: p => p.OrderBy(p => p.PostedOn), page: page, pageSize: pageSize);
    }

    public async Task<IEnumerable<PostVM>> MostInterestingAsync(int? page, int? pageSize)
    {
        return await unitOfWork.PostRepository.GetAsync<PostVM>(orderBy: p => p.OrderBy(p => p.TotalRate), page: page, pageSize: pageSize);
    }

    public async Task<IEnumerable<PostVM>> MostViewedAsync(int? page, int? pageSize)
    {
        return await unitOfWork.PostRepository.GetAsync<PostVM>(orderBy: p => p.OrderBy(p => p.ViewCount), page: page, pageSize: pageSize);

    }

    public async Task<IEnumerable<PostVM>> PublishedAsync(int? page, int? pageSize)
    {
        return await unitOfWork.PostRepository.GetAsync<PostVM>(filter: c => c.Published == true, page: page, pageSize: pageSize);
    }

    public async Task<IEnumerable<PostVM>> UnPublishedAsync(int? page, int? pageSize)
    {
        return await unitOfWork.PostRepository.GetAsync<PostVM>(filter: c => c.Published == false, page: page, pageSize: pageSize);
    }

    public override async Task UpdateAsync(PostUM entityToUpdate)
    {
        Repositories.Bases.IBaseRepository<PostTag> postTagRepository = unitOfWork.GetRepository<PostTag>();
        IEnumerable<PostTag> postTag = await postTagRepository.GetAsync(filter: pt => pt.PostId == entityToUpdate.Id);
        unitOfWork.GetRepository<PostTag>().DeleteRange(postTag);
        await base.UpdateAsync(entityToUpdate);
    }
}
