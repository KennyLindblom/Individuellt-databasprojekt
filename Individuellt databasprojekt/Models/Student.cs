using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class Student
    {
        public Student()
        {
            Grade = new HashSet<Grade>();
            ImportanStudentInfo = new HashSet<ImportanStudentInfo>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PersonNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? ClassId { get; set; }
        public int? GenderId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Grade> Grade { get; set; }
        public virtual ICollection<ImportanStudentInfo> ImportanStudentInfo { get; set; }
    }
}
