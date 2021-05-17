using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.ViewModels
{
    public class UploadViewModel
        {
            [Required(ErrorMessage = "Please select a file.")]
            [DataType(DataType.MultilineText, ErrorMessage = "Only textfiles allowed")]
            public IFormFile ConfigFile { get; set; }
        }
}
