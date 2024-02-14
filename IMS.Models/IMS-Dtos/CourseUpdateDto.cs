using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models.IMS_Dtos
{
    public class CourseUpdateDto
    {
        /// <summary>
        /// Gets or sets the ID of the course to update.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the updated name of the course.
        /// </summary>
        [Required]
        public string CourseName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the updated type of the course.
        /// </summary>
        [Required]
        public string CourseType { get; set; } = null!;

        /// <summary>
        /// Gets or sets the updated duration of the course in months.
        /// </summary>
        [Required]
        public decimal CourseDuration { get; set; }

        /// <summary>
        /// Gets or sets the updated fee for the course.
        /// </summary>
        [Required]
        public decimal CourseFee { get; set; }

        /// <summary>
        /// Gets or sets the updated content or description of the course.
        /// </summary>
        [Required]
        public string CourseContent { get; set; } = null!;
    }
}
