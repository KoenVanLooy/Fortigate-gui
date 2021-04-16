using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class ConfigFile
    {
        public int ConfigfileID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public int FilterID { get; set; }
        public Filter Filter { get; set; }
        public Ip4Policy Ip4Policy { get; set; }
        public ICollection<Ip4Policy> Ip4Policies { get; set; }
        public VPNtunnel VPNtunnel { get; set; }
        public ICollection<VPNtunnel> VPNtunnels { get; set; }
    }
}
