using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class FortiUser
    {
        public int FortiUserID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(35, ErrorMessage = "Maximum 35 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        //navigation properties
        //meerdere usergroups
        public List<UserGroup> UserGroups { get; set; }

    }
}