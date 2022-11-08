using JustBlog.Entities.Context;
using JustBlog.Entities.Entities;
using JustBlog.Repositories.Bases;

namespace JustBlog.Repositories.Posts;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(ApplicationDbContext context) : base(context)
    {
    }
}
