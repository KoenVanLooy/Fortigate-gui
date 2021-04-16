using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Models
{
    public class VpnSetting
    {
        public int VpnSettingID { get; set; }

        [Required(ErrorMessage = "Server Certification name is required")]
        [MaxLength(35, ErrorMessage = "Maximum 35 characters")]
        [Display(Name = "Server Certification Name", Prompt = "enter server certification name")]
        public string ServerCert { get; set; }

        [Required(ErrorMessage = "Tunnel Ip Pool is required")]
        [MaxLength(79, ErrorMessage = "Maximum 79 characters")]
        [Display(Name = "Tunnel Ip Pool", Prompt = "enter tunnel ip pool")]
        public string TunnelIpPool { get; set; }

        [Required(ErrorMessage = "Tunnel Ip Pool V6 is required")]
        [MaxLength(79, ErrorMessage = "Maximum 79 characters")]
        [Display(Name = "Tunnel Ip Pool V6", Prompt = "enter tunnel ip pool V6")]
        public string TunnelIpv6Pool { get; set; }

        [Required(ErrorMessage = "Source Interface is required")]
        [MaxLength(35, ErrorMessage = "Maximum 35 characters")]
        [Display(Name = "Source Interface", Prompt = "enter source interface")]
        public string SourceInterface { get; set; }

        [Required(ErrorMessage = "Source Address is required")]
        [MaxLength(79, ErrorMessage = "Maximum 79 characters")]
        [Display(Name = "Source Address", Prompt = "enter source address")]
        public string SourceAddress { get; set; }

        [Required(ErrorMessage = "Source Address V6 is required")]
        [MaxLength(79, ErrorMessage = "Maximum 79 characters")]
        [Display(Name = "Source Address V6", Prompt = "enter source address V6")]
        public string SourceAddressV6 { get; set; }

        [Required(ErrorMessage = "Default Portal is required")]
        [MaxLength(35, ErrorMessage = "Maximum 35 characters")]
        [Display(Name = "Default Portal", Prompt = "enter default portal")]
        public string DefaultPort { get; set; }

        //navigation properties

        //één group
        public int GroupID { get; set; }
        public Group group { get; set; }

        //één portal
        public int? VpnPortalID { get; set; }
        public VpnPortal vpnPortal { get; set; }
    }
}
