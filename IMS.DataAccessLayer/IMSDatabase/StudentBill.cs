using System;
using System.Collections.Generic;

namespace IMS.DataAccessLayer.IMSDatabase
{
    public partial class StudentBill
    {
        public StudentBill()
        {
            BillWisePaymentDetails = new HashSet<BillWisePaymentDetail>();
        }

        public int StudentBillId { get; set; }
        public int? CoursesJoinedId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public DateTime DueDate { get; set; }
        public decimal BillAmount { get; set; }
        public bool? Status { get; set; }

        public virtual Course? Course { get; set; }
        public virtual CoursesJoined? CoursesJoined { get; set; }
        public virtual Student? Student { get; set; }
        public virtual ICollection<BillWisePaymentDetail> BillWisePaymentDetails { get; set; }
    }
}
