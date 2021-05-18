using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class StaticRoute
    {
        public int StaticRouteID { get; set; }

        public int InterfaceID { get; set; }
        public Interface Interface { get; set; }

        [Required(ErrorMessage = "Associated Zone is required")]
        [MaxLength(35, ErrorMessage = "Max 35 characters.")]
        [Display(Name = "Destination Subnet")]
        public string DestinationSubnet { get; set; }

        [Required(ErrorMessage = "Associated Zone is required")]
        [MaxLength(35, ErrorMessage = "Max 35 characters.")]
        
        public string Gateway { get; set; }

    }
}
