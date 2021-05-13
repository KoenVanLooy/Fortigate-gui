using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class StaticRoute
    {
        public int StaticRouteID { get; set; }

        public int InterfaceID { get; set; }
        public Interface Interface { get; set; }

        public string DestinationSubnet { get; set; }

        public string Gateway { get; set; }

    }
}
