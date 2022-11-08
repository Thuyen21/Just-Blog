using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustBlog.Entities.Entities;

public class Post
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
    public int? TotalRate { get; set; }
    public decimal? Rate => RateCount == 0 ? 0 : TotalRate / RateCount;
    [ForeignKey("Category")]
    public Guid CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public virtual List<PostTag> PostTags { get; set; } = new();
}
