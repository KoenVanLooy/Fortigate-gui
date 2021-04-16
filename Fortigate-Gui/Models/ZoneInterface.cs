using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class ZoneInterface
    {
        public int ZoneInterfaceID { get; set; }

        public int InterfaceID { get; set; }
        [ForeignKey("InterfaceID")]
        public Interface Interface { get; set; }
        public int ZoneID { get; set; }
        public Zone Zone { get; set; }
    }
}
