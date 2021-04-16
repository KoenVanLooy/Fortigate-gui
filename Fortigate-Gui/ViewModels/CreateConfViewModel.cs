using Fortigate_Gui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class CreateConfViewModel
    {
        public List<Interface> Interfaces { get; set; }
        public List<Zone> Zones { get; set; }
        public List<FirewallAddress> FirewallAddresses { get; set; }
    }
}
