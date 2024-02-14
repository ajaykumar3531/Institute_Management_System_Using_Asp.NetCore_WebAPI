using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models.IMS_Dtos
{
    public class PaymentUpdateDto
    {
        /// <summary>
        /// Gets or sets the ID of the payment mode to be updated.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the updated name of the payment mode.
        /// </summary>
        [Required]
        public string PaymentModeName { get; set; } = null!;
    }
}
