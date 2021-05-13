using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class VPNtunnel
    {
        public int VPNtunnelID { get; set; }
        public bool TunnelMode { get; set; }
        public bool SplitTunneling { get; set; }
        public string IpPool { get; set; }
        public Setting Setting { get; set; }
        public ICollection<Setting> Settings { get; set; }
    }
}
