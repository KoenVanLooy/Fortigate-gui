using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class AccessInterface
    {


        public int AccessInterfaceID { get; set; }

        public int InterfaceID { get; set; }
        public Interface Interface { get; set; }

        public int EnumAccesID { get; set; }
        public EnumAcces EnumAcces { get; set; }

    }
}
