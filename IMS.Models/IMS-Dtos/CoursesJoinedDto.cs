using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models.IMS_Dtos
{
    public class CoursesJoinedDto
    {
        /// <summary>
        /// Gets or sets the ID of the student enrolling in a course.
        /// </summary>
        [Required]
        public int? StudentId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the course being enrolled in.
        /// </summary>
        [Required]
        public int? CourseId { get; set; }

        /// <summary>
        /// Gets or sets the course fee for the enrollment.
        /// </summary>
        [Required]
        public decimal CourseFee { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the course fee.
        /// </summary>
        [Required]
        public decimal? Discount { get; set; }
    }
}
