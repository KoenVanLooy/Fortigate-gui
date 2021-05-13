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
        public List<Ip4Policy> Ip4Policies { get; set; }

        public List<StaticRoute> StaticRoutes { get; set; }

        public List<Group> Groups { get; set; }
        public List<VpnSetting> VpnSettings { get; set; }

        public bool DnsFilter { get; set; }

       
    }
}
