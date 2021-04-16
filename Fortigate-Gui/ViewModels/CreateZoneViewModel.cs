using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class CreateZoneViewModel
    {
        public Zone Zone { get; set; }

        public IEnumerable<SelectListItem> InterfaceList { get; set; }

        public IEnumerable<int> SelectedInterface { get; set; }
    }
}
