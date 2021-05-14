using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class EditStaticRouteViewModel
    {
        public StaticRoute StaticRoute { get; set; }
        public SelectList Interfaces { get; set; }
    }
}
