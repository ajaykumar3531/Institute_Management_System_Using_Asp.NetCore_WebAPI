using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models.IMS_Dtos
{
    public class StudentUpdateDto
    {
        /// <summary>
        /// Gets or sets the ID of the student to be updated.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the student.
        /// </summary>
        [Required]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the last name of the student (optional).
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the surname of the student.
        /// </summary>
        [Required]
        public string Surname { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date of birth of the student.
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the mobile number of the student.
        /// </summary>
        [Required]
        public string Mobile { get ; set; }
        

        /// <summary>
        /// Gets or sets the email address of the student.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets the address of the student (optional).
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the city name of the student (optional).
        /// </summary>
        public string? CityName { get; set; }

        /// <summary>
        /// Gets or sets the state name of the student (optional).
        /// </summary>
        public string? StateName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the student record.
        /// </summary>
        [Required]
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the status of the student.
        /// </summary>
        public bool Status { get; set; }
    }
}
