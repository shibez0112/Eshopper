using System.ComponentModel.DataAnnotations;
namespace Eshopper.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}