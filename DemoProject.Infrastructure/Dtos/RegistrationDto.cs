using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DemoProject.Dtos
{
    public class RegistrationDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
