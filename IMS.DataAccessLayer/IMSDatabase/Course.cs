using System;
using System.Collections.Generic;

namespace IMS.DataAccessLayer.IMSDatabase
{
    public partial class Course
    {
        public Course()
        {
            Batches = new HashSet<Batch>();
            BillWisePaymentDetails = new HashSet<BillWisePaymentDetail>();
            CoursesJoineds = new HashSet<CoursesJoined>();
            StudentBills = new HashSet<StudentBill>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string CourseType { get; set; } = null!;
        public decimal CourseDuration { get; set; }
        public decimal CourseFee { get; set; }
        public string CourseContent { get; set; } = null!;

        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<BillWisePaymentDetail> BillWisePaymentDetails { get; set; }
        public virtual ICollection<CoursesJoined> CoursesJoineds { get; set; }
        public virtual ICollection<StudentBill> StudentBills { get; set; }
    }
}
