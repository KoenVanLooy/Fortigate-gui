using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class FirewallAddress
    {
        public int FirewallAddressID { get; set; }
        public string Name { get; set; }
        public string AssociatedZone { get; set; }

        public string Subnet { get; set; }

        
    }
}
