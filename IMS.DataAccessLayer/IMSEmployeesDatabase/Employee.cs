using System;
using System.Collections.Generic;

namespace IMS.DataAccessLayer.IMSEmployeesDatabase
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
