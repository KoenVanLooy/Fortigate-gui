using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class CreateIp4PolicyViewModel
    {
        public Ip4Policy ip4Policy { get; set; }
        public SelectList DestinationInterface { get; set; }
        public SelectList SourceInterface { get; set; }
    }
}
