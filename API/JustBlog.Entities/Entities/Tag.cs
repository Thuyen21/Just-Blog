using System.ComponentModel.DataAnnotations;

namespace JustBlog.Entities.Entities
{
    public class Tag
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Tag Name is required.")]
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(255)]
        public string? UrlSlug { get; set; }
        [StringLength(1024)]
        public string? Description { get; set; }
        public virtual List<PostTag> PostTag { get; set; } = new();
    }
}
