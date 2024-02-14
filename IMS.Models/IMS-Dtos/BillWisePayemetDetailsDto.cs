using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models.IMS_Dtos
{
    public class BillWisePayemetDetailsDto
    {
        /// <summary>
        /// Gets or sets the ID of the associated student bill.
        /// </summary>
        [Required]
        public int? StudentBillId { get; set; }

        /// <summary>
        /// Gets or sets the amount paid for the bill.
        /// </summary>
        [Required]
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// Gets or sets the due date for the payment.
        /// </summary>
        [Required]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated student.
        /// </summary>
        [Required]
        public int? StudentId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated course.
        /// </summary>
        [Required]
        public int? CourseId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the payment mode used for the payment.
        /// </summary>
        [Required]
        public int? PaymentModeId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the person who collected the payment.
        /// </summary>
        [Required]
        public int CollectedBy { get; set; }
    }
}
