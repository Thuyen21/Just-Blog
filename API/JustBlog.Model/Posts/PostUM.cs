using System.ComponentModel.DataAnnotations;

namespace JustBlog.Model.Posts;

public class PostUM
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required(ErrorMessage = "Post Title is required.")]
    [StringLength(255)]
    public string? Title { get; set; }
    [StringLength(255)]
    public string? ShortDescription { get; set; }
    [StringLength(1024)]
    public string? Description { get; set; }
    [StringLength(255)]
    public string? Content { get; set; }
    [StringLength(255)]
    public string? UrlSlug { get; set; }
    public bool Published { get; set; }
    public DateTime PostedOn { get; set; }
    public DateTime? Modified { get; set; }
    public int? ViewCount { get; set; }
    public int? RateCount { get; set; }
    [Required(ErrorMessage = "Category is required.")]
    public Guid? CategoryId { get; set; }
    public virtual List<Guid> Tags { get; set; } = new();
}
