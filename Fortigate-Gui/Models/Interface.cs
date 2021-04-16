using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class Interface
    {
        public int InterfaceID { get; set; }


        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(20,ErrorMessage ="Max 20 characters.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters.")]
        public string Vdom { get; set; }


        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(20, ErrorMessage = "Max 20 characters.")]
        public string Alias { get; set; }

        //[DisplayName("Ip Address")]
        //[Required(ErrorMessage = "This Field is required.")]
        public string Ip { get; set; }
        public bool SecondaryIp { get; set; }

        [MaxLength(20, ErrorMessage = "Max 20 characters.")]



        [Required(ErrorMessage = "This Field is required.")]
        public string Subnet { get; set; }


        [DisplayName("Allow Access")]
        [Required(ErrorMessage = "This Field is required.")] 
        public int EnumAccesID { get; set; }

        public EnumAcces EnumAcces { get; set; }


        [DisplayName("Mode")]
        [Required(ErrorMessage = "This Field is required.")]
        public int EnumModeID { get; set; }

       
        public EnumMode EnumMode { get; set; }
    }
}
