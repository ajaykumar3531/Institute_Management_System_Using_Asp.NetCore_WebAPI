using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models.IMS_Dtos
{
    public class FacultyDto
    {
        /// <summary>
        /// Gets or sets the name of the faculty.
        /// </summary>
        [Required]
        public string FacultyName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the years of experience of the faculty.
        /// </summary>
        [Required]
        public decimal YearsOfExperience { get; set; }

        /// <summary>
        /// Gets or sets the mobile number of the faculty.
        /// </summary>
        [Required]
        public string Mobile { get; set; } = null!;

        /// <summary>
        /// Gets or sets the email address of the faculty.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;
    }
}
