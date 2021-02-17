using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Ip4Policy
    {
        public int Ip4PolicyID { get; set; }
        public string SourceInterface { get; set; }
        public string DestinationInterface { get; set; }
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string Type { get; set; }
    }
}
