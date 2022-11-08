using JustBlog.Entities.Entities;
using JustBlog.Model.Posts;
using JustBlog.Services.Base;

namespace JustBlog.Services.Posts;

public interface IPostService : IBaseService<Post, PostCM, PostVM, PostUM>
{
    Task<IEnumerable<PostVM>> LatestAsync(int? page, int? pageSize);
    Task<IEnumerable<PostVM>> MostInterestingAsync(int? page, int? pageSize);
    Task<IEnumerable<PostVM>> MostViewedAsync(int? page, int? pageSize);
    Task<IEnumerable<PostVM>> PublishedAsync(int? page, int? pageSize);
    Task<IEnumerable<PostVM>> UnPublishedAsync(int? page, int? pageSize);
    Task<IEnumerable<PostVM>> CategoryNameAsync(string? name);
}
