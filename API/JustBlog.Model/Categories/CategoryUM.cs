using System.ComponentModel.DataAnnotations;

namespace JustBlog.Model.Categories;

public class CategoryUM
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required(ErrorMessage = "Category name is required.")]
    [StringLength(255)]
    public string? Name { get; set; }
    [StringLength(255)]
    public string? UrlSlug { get; set; }
    [StringLength(1024)]
    public string? Description { get; set; }
}
