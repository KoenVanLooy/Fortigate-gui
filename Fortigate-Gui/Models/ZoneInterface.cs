using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class ZoneInterface
    {
        public int ZoneInterfaceID { get; set; }
        public Zone Zone { get; set; }
        public ICollection<Zone> Zones { get; set; }
        public Interface Interface { get; set; }
        public ICollection<Interface> Interfaces { get; set; }
    }
}
