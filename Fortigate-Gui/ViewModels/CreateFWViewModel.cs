using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class CreateFWViewModel
    {
        public FirewallAddress FirewallAddress { get; set; }

        public SelectList Zones { get; set; }
    }
}
