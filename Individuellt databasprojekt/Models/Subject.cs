using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Grade = new HashSet<Grade>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int? EmployeeId { get; set; }
        public bool? IsAcctive { get; set; }

        public virtual ICollection<Grade> Grade { get; set; }
    }
}
