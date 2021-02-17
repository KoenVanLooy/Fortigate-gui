using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Interface
    {
        public int InterfaceID { get; set; }
        public string Name { get; set; }
        public string Vdom { get; set; }
        public int EnumAliasID { get; set; }
        public EnumAlias EnumAlias { get; set; }
        public string Ip { get; set; }
        public bool SecondaryIp { get; set; }
        public string Subnet { get; set; }
        public int EnumAccesID { get; set; }
        public EnumAcces EnumAcces { get; set; }
        public string EnumModeID { get; set; }
        public EnumMode EnumMode { get; set; }
    }
}
