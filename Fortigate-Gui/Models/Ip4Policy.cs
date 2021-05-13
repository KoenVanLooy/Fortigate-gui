using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Ip4Policy
    {
        public int Ip4PolicyID { get; set; }

       
        public int? SourceInterfaceID { get; set; }

        [ForeignKey("SourceInterfaceID")]
        public virtual Zone SourceInterface { get; set; }

        
        public int? DestinationInterfaceID { get; set; }


        [ForeignKey("DestinationInterfaceID")]
        public virtual Zone DestinationInterface { get; set; }

       
        public string SourceAddress { get; set; }
        
        public string DestinationAddress { get; set; }
        public List<Ip4PolicyService> Ip4PolicyServices { get; set; }

        public virtual int? ActionID { get; set; }
        public Action Action { get; set; }

        public virtual int? NatID { get; set; }
        public Nat Nat { get; set; }

        public List<ZoneInterface> ZoneInterfaces { get; set; }
        public bool DnsFilter { get; set; }
        public bool AvFilter { get; set; }
        public bool AppFilter { get; set; }
        public bool SslFilter { get; set; }
        public bool WebFilter { get; set; }
        public bool IpsFilter { get; set; }

        public bool ProxyFilter { get; set; }
    }
}
