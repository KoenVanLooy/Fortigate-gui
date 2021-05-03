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

        //navigation properties
        //één configfile
        public int? ConfigFileID { get; set; }
        public ConfigFile ConfigFile { get; set; }

        
        //meerdere usergroups
        public List<UserGroup> UserGroups { get; set; }
    }
}