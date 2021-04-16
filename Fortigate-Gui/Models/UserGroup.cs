using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class UserGroup
    {
        public int UserGroupID { get; set; }

        //navigation properties, meer op meer relatie tussen users en groups
        public int FortiUserID { get; set; }
        public FortiUser fortiUser { get; set; }

        public int GroupID { get; set; }
        public Group group { get; set; }
    }
}