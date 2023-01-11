using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW5.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientCompany { get; set; }
        public string ClientEmail { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}
