using System.ComponentModel.DataAnnotations.Schema;

namespace JustBlog.Entities.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    [ForeignKey("Post")]
    public Guid? PostId { get; set; }
    public virtual Post? Post { get; set; }
    public string? Header { get; set; }
    public string? Body { get; set; }
    public DateTime Time { get; set; }
}
