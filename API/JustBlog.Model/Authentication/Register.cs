using System.ComponentModel.DataAnnotations;

namespace JustBlog.Model.Authentication;

public class Register
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [MinLength(6)]
    [MaxLength(50)]
    public string? Password { get; set; }
    [Required]
    public string? PasswordConfirm { get; set; }

}
