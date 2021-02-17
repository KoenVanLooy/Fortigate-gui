using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class ZonePolicy
    {
        public int ZonePolicyID { get; set; }
        public int Ip4PolicyID { get; set; }
        public Ip4Policy Ip4Policy { get; set; }
        public int ZoneID { get; set; }
        public Zone Zone { get; set; }
    }
}
