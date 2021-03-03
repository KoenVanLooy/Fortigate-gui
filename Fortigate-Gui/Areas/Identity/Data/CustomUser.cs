using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Areas.Identity.Data
{
    public class CustomUser : IdentityUser
    {
        [PersonalData]
        public Customer Customer { get; set; }
    }
}
