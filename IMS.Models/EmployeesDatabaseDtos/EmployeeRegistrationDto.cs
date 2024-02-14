using System.ComponentModel.DataAnnotations;

namespace IMS.Models.EmployeesDatabaseDtos
{
    public class EmployeeRegistrationDto
    {


        /// <summary>
        /// Gets or sets the Full ame of the employee.
        /// </summary>
        [Required]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets the password hash of the employee.
        /// </summary>
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$", ErrorMessage = "Password must be at least 8 characters and contain at least one uppercase letter, one lowercase letter, and one digit.")]
        public string Password { get; set; } = null!;

    
    }
}
