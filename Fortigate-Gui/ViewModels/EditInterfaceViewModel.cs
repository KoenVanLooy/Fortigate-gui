using Fortigate_Gui.Models;
using Fortigate_Gui.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class EditInterfaceViewModel : IpInterfaceViewmodel
    {
        public Interface Interface { get; set; }

        [IPAddressAttribute]
        [Display(Name = "IP Address")]
        public string IpAddress { get; set; }
        public SelectList Modes { get; set; }
        public IEnumerable<SelectListItem> AccessList { get; set; }
        [Display(Name = "Allow Access")]
        public IEnumerable<int> SelectedEnumAcces { get; set; }
    }
}
