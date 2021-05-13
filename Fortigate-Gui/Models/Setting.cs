using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Setting
    {
        public int SettingID { get; set; }
        public string ServerCert { get; set; }
        public string TunnelIpPool { get; set; }
        public string TunnelIpv6Pool { get; set; }
        public string SourceInterface { get; set; }
        public string StringSourceAddress { get; set; }
        public string SourceAddress { get; set; }
        public string SourceAddressV6 { get; set; }
        public string DefaultPort { get; set; }
    }
}
