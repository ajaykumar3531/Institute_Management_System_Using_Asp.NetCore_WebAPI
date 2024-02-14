using System.ComponentModel.DataAnnotations;

namespace IMS.Models.EmployeesDatabaseDtos
{
    public class EmployeeLoginDto
    {
       
        /// <summary>
        /// Gets or sets the employee's email address.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets the employee's password.
        /// </summary>
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$", ErrorMessage = "Password must be at least 8 characters and contain at least one uppercase letter, one lowercase letter, and one digit.")]
        public string Password { get; set; } = null!;
    }
}
