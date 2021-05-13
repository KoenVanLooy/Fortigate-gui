using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class AddOrEditVpnSettingViewModel
    {
        public VpnSetting VpnSetting { get; set; }
        public SelectList VpnPortals { get; set; }
        public SelectList Groups { get; set; }
    }
}
