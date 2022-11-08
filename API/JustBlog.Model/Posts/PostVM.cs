namespace JustBlog.Model.Posts;

public class PostVM
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? UrlSlug { get; set; }
    public bool Published { get; set; }
    public DateTime PostedOn { get; set; }
    public DateTime? Modified { get; set; }
    public int? ViewCount { get; set; }
    public int? RateCount { get; set; }
    public int? TotalRate { get; set; }
    public decimal? Rate => RateCount == 0 ? 0 : TotalRate / RateCount;
    public Guid CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public virtual List<string> Tags { get; set; } = new();
}
