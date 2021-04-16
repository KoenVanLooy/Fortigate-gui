using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Group
    {
        public int GroupID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public int ConfigFileID { get; set; }
        public ConfigFile configFile { get; set; }

        //navigation properties
        //meerdere usergroups
        public List<UserGroup> userGroups { get; set; }
    }
}
