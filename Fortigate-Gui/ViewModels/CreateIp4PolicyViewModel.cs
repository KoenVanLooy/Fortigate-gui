using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class CreateIp4PolicyViewModel
    {
        public Ip4Policy ip4Policy { get; set; }
        public SelectList DestinationInterface { get; set; }
        public SelectList SourceInterface { get; set; }
        public SelectList Actions { get; set; }
        public SelectList Nat { get; set; }
        public IEnumerable<SelectListItem> ServiceList { get; set; }
        [Display(Name = "Services")]
        public IEnumerable<int> SelectedService { get; set; }

                
    }
}
