using System;
using System.ComponentModel.DataAnnotations;

namespace IMS.Models.IMS_Dtos
{
    public class PaymentDto
    {
        /// <summary>
        /// Gets or sets the name of the payment mode.
        /// </summary>
        [Required]
        public string PaymentModeName { get; set; } = null!;
    }
}
