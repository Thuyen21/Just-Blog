using JustBlog.Entities.Entities;
using JustBlog.Model.Common;
using JustBlog.Model.Tags;
using JustBlog.Services.Base;

namespace JustBlog.Services.Tags;

public interface ITagService : IBaseService<Tag, TagCM, TagVM, TagUM>
{
    Task<IEnumerable<Select>> GetToSelectAsync(int? page, int? pageSize);
}
