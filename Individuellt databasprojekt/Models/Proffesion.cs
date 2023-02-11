using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Individuellt_databasprojekt.Models
{
    public partial class Proffesion
    {
        public Proffesion()
        {
            Employee = new HashSet<Employee>();
        }

        public int ProffessionId { get; set; }
        public string ProffessionName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
