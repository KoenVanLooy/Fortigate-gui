using Fortigate_Gui.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Admin { get; set; }

        [ForeignKey("CustomUser")]
        public string UserID { get; set; }
        public CustomUser CustomUser { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"CustomerID: {CustomerID}; ");
            stringBuilder.Append($"Firstname: {Firstname}; ");
            stringBuilder.Append($"Lastname: {Lastname}; ");

            return stringBuilder.ToString();
        }

    }
}
