using System.ComponentModel.DataAnnotations;

namespace Web.Models.Identity
{
public class Register
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string FullName { get; set; }

}