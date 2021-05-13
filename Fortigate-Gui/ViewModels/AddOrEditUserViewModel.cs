using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class AddOrEditUserViewModel
    {
        public FortiUser FortiUser { get; set; }
        public IEnumerable<SelectListItem> GroupList { get; set; }
        public IEnumerable<int> SelectedGroups { get; set; }

        public AddOrEditUserViewModel()
        {
            SelectedGroups = new List<int>();
        }

    }
}
