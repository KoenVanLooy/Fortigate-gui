using Fortigate_Gui.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }
        public ConfigFile Configfile { get; set; }
        public ICollection<ConfigFile> Configfiles { get; set; }

        [ForeignKey("CustomUser")]
        public string UserID { get; set; }
        public CustomUser CustomUser { get; set; }

    }
}
