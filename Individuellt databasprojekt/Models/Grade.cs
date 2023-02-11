using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public int? Grade1 { get; set; }
        public DateTime? DateOfGrade { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public int? EmployerId { get; set; }

        public virtual Employee Employer { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
