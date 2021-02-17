using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FactoryName { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
