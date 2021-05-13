using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string Name { get; set; }

        public List<Ip4PolicyService> Ip4PolicyServices { get; set; }
    }
}
