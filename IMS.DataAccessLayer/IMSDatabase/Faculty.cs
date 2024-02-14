using System;
using System.Collections.Generic;

namespace IMS.DataAccessLayer.IMSDatabase
{
    public partial class Faculty
    {
        public Faculty()
        {
            Batches = new HashSet<Batch>();
        }

        public int FacultyId { get; set; }
        public string FacultyName { get; set; } = null!;
        public decimal YearsOfExperience { get; set; }
        public string Mobile { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Batch> Batches { get; set; }
    }
}
