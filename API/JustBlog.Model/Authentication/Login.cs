using System.ComponentModel.DataAnnotations;

namespace JustBlog.Model.Authentication;

public class Login
{
    [EmailAddress]
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
    public bool? Remember { get; set; }
}
