using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class ImportanStudentInfo
    {
        public int InfoId { get; set; }
        public int? StudentId { get; set; }
        public string Info { get; set; }

        public virtual Student Student { get; set; }
    }
}
