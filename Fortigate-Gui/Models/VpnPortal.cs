using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Fortigate_Gui.Models
    {
        public class VpnPortal
        {
            public int VpnPortalID { get; set; }

            [Required(ErrorMessage = "Portal Name is required")]
            [MaxLength(35, ErrorMessage = "Maximum 35 characters")]
            [Display(Name = "Portal Name", Prompt = "enter portal name")]
            public string PortalName { get; set; }

            public bool TunnelMode { get; set; }

            public bool SplitTunneling { get; set; }

            public bool WebMode { get; set; }

            public bool AutoConnect { get; set; }

            public bool KeepAlive { get; set; }

            public bool SavePassword { get; set; }

            [Required(ErrorMessage = "Ip Pool is required")]
            [MaxLength(79, ErrorMessage = "Maximum 79 characters")]
            [Display(Name = "Ip Pool", Prompt = "enter ip pool")]
            public string IpPool { get; set; }

            [MaxLength(79, ErrorMessage = "Maximum 79 characters")]
            [Display(Name = "Split Tunnel Route Address", Prompt = "enter split tunnel route address")]
            public string SplitTunnelingRoute { get; set; }

            //navigation properties
            //één configfile
            public int? ConfigFileID { get; set; }
            public ConfigFile configFile { get; set; }

        }
    }
}
