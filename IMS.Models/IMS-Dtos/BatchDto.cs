using System.ComponentModel.DataAnnotations;

namespace IMS.Models.IMS_Dtos
{
    public class BatchDto
    {
        /// <summary>
        /// Gets or sets the name of the batch.
        /// </summary>
        [Required]
        public string BatchName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the ID of the associated course for the batch.
        /// </summary>
        [Required]
        public int? CourseId { get; set; }

        /// <summary>
        /// Gets or sets the timings for the batch.
        /// </summary>
        [Required]
        public string Timings { get; set; } = null!;

        /// <summary>
        /// Gets or sets the maximum strength (capacity) of the batch.
        /// </summary>
        [Required]
        public int MaxStrength { get; set; }

        /// <summary>
        /// Gets or sets the ID of the faculty assigned to the batch.
        /// </summary>
        [Required]
        public int? FacultyId { get; set; }

        /// <summary>
        /// Gets or sets the status of the batch (e.g., active or inactive).
        /// </summary>
        [Required]
        public bool? Status { get; set; }
    }
}
