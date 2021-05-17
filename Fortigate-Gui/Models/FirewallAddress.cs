using Fortigate_Gui.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class FirewallAddress
    {
        public int FirewallAddressID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(35, ErrorMessage = "Max 35 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Associated Zone is required")]
        [MaxLength(35, ErrorMessage = "Max 35 characters.")]
        [Display(Name="Associated Zone")]
        public string AssociatedZone { get; set; }
        [Required(ErrorMessage = "Subnet is required")]
        [MaxLength(35, ErrorMessage = "Max 35 characters.")]
        public string Subnet { get; set; }

        
    }
}
