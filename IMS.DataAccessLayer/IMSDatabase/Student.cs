using System;
using System.Collections.Generic;

namespace IMS.DataAccessLayer.IMSDatabase
{
    public partial class Student
    {
        public Student()
        {
            BillWisePaymentDetails = new HashSet<BillWisePaymentDetail>();
            CoursesJoineds = new HashSet<CoursesJoined>();
            StudentBills = new HashSet<StudentBill>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Surname { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string Mobile { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public string? CityName { get; set; }
        public string? StateName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<BillWisePaymentDetail> BillWisePaymentDetails { get; set; }
        public virtual ICollection<CoursesJoined> CoursesJoineds { get; set; }
        public virtual ICollection<StudentBill> StudentBills { get; set; }
    }
}
