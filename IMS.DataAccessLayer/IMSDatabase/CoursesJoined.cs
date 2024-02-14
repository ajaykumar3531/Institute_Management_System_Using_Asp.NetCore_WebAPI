using System;
using System.Collections.Generic;

namespace IMS.DataAccessLayer.IMSDatabase
{
    public partial class CoursesJoined
    {
        public CoursesJoined()
        {
            StudentBills = new HashSet<StudentBill>();
        }

        public int CoursesJoinedId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public decimal CourseFee { get; set; }
        public decimal? Discount { get; set; }
        public DateTime DateOfJoining { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
        public virtual ICollection<StudentBill> StudentBills { get; set; }
    }
}
