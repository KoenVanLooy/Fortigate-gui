using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Ip4PolicyService
    {
        public int Ip4PolicyServiceID { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }
        public int Ip4PolicyID { get; set; }
        public Ip4Policy Ip4Policy { get; set; }
    }
}
