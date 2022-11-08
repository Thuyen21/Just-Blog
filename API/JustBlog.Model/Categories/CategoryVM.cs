namespace JustBlog.Model.Categories
{
    public class CategoryVM
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? UrlSlug { get; set; }
        public string? Description { get; set; }
        public List<string> PostTitles { get; set; } = new();
        public List<Guid> PostIds { get; set; } = new();
    }
}
