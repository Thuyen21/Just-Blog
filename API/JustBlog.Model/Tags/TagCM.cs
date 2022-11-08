using System.ComponentModel.DataAnnotations;

namespace JustBlog.Model.Tags;

public class TagCM
{
    [Required(ErrorMessage = "Tag Name is required.")]
    [StringLength(255)]
    public string? Name { get; set; }
    [StringLength(255)]
    public string? UrlSlug { get; set; }
    [StringLength(1024)]
    public string? Description { get; set; }
}
