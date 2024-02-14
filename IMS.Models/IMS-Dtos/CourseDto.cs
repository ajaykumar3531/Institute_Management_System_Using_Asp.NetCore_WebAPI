using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models.IMS_Dtos
{
    public class CourseDto
    {
        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        [Required]
        public string CourseName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the type of the course.
        /// </summary>
        [Required]
        public string CourseType { get; set; } = null!;

        /// <summary>
        /// Gets or sets the duration of the course in months.
        /// </summary>
        [Required]
        public decimal CourseDuration { get; set; }

        /// <summary>
        /// Gets or sets the fee for the course.
        /// </summary>
        [Required]
        public decimal CourseFee { get; set; }

        /// <summary>
        /// Gets or sets the content or description of the course.
        /// </summary>
        [Required]
        public string CourseContent { get; set; } = null!;
    }
}
