using Fortigate_Gui.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class AddOrEditGroupViewModel
    {
        public Group Group { get; set; }
        public IEnumerable<SelectListItem> FortiUserList { get; set; }
        public IEnumerable<int> SelectedFortiUsers { get; set; }

        public AddOrEditGroupViewModel()
        {
            SelectedFortiUsers = new List<int>();
        }
    }
}
