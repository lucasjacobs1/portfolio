using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTO.Requests
{
    public class CreateLoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        //[StringLength(255, MinimumLength = 8)]
        //[RegularExpression(@"^(?=.*[!@#$%^&*(),.?"":{}|<>]).{8,255}$", ErrorMessage = "Password must be between 8 and 255 characters long and contain at least one special character.")]
        public string Password { get; set; } = string.Empty;
    }
}

