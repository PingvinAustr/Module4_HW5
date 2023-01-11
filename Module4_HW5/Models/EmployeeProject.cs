using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW5.Models
{
    public class EmployeeProject
    {
        public int EmployeeProjectId { get; set; }
        public double Rate { get; set; }
        public DateTime StartedDate { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
