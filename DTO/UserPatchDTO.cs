using System.ComponentModel.DataAnnotations;

namespace UserMvcApp.DTO
{
    public class UserPatchDTO
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username should be between 2 and 50 characters")]
        public string? Username { get; set; }

        [StringLength(50, ErrorMessage = "Email should not exceed 50 characters")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        public string? Email { get; set; }

        [StringLength(32, ErrorMessage = "Password should not exceed 32 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and contain at least one lowercase letter, one uppercase letter, one digit, and one special character.")]
        public string? Password { get; set; }

        [StringLength(10, ErrorMessage = "Phone number should not exceed 10 characters")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }
    }
}
