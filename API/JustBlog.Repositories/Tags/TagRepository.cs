using JustBlog.Entities.Context;
using JustBlog.Entities.Entities;
using JustBlog.Repositories.Bases;

namespace JustBlog.Repositories.Tags;

public class TagRepository : BaseRepository<Tag>, ITagRepository
{
    public TagRepository(ApplicationDbContext context) : base(context)
    {
    }
}

