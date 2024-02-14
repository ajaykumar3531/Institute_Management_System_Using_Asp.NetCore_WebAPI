using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models.IMS_Dtos
{
    public class StudentBillsDto
    {
        /// <summary>
        /// Gets or sets the ID of the associated course joined by the student.
        /// </summary>
        [Required]
        public int? CoursesJoinedId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the student who the bill is associated with.
        /// </summary>
        [Required]
        public int? StudentId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the course for which the bill is generated.
        /// </summary>
        [Required]
        public int? CourseId { get; set; }

        /// <summary>
        /// Gets or sets the due date for the bill.
        /// </summary>
        [Required]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of the bill.
        /// </summary>
        [Required]
        public decimal BillAmount { get; set; }

        /// <summary>
        /// Gets or sets the status of the bill (e.g., paid or unpaid).
        /// </summary>
        [Required]
        public bool? Status { get; set; }
    }
}
