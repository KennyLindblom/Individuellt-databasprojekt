using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Grade = new HashSet<Grade>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? DateOfHired { get; set; }
        public int? ProffesionId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Proffesion Proffesion { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
    }
}
