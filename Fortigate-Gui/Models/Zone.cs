using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Zone
    {
        public int ZoneID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(35, ErrorMessage = "Max 35 characters.")]
        public string Name { get; set; }
        public List<ZoneInterface> ZoneInterfaces { get; set; }
    }
}
