using System;
using System.Collections.Generic;

namespace IMS.DataAccessLayer.IMSDatabase
{
    public partial class Batch
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; } = null!;
        public int? CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Timings { get; set; } = null!;
        public int MaxStrength { get; set; }
        public int? FacultyId { get; set; }
        public bool? Status { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Faculty? Faculty { get; set; }
    }
}
