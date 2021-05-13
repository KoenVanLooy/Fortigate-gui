using Fortigate_Gui.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fortigate_Gui.ValidationAttributes
{
    public class IPAddressAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IpInterfaceViewmodel viewModel = (IpInterfaceViewmodel)validationContext.ObjectInstance;

            const string regexPattern = @"^([\d]{1,3}\.){3}[\d]{1,3}$";
            var regex = new Regex(regexPattern);
            if (string.IsNullOrEmpty(viewModel.IpAddress))
            {
                return new ValidationResult("IP address  is null");
            }
            if (!regex.IsMatch(viewModel.IpAddress) || viewModel.IpAddress.Split('.').SingleOrDefault(s => int.Parse(s) > 255) != null)
                return new ValidationResult("Invalid IP Address");


            return ValidationResult.Success;
        }
    }
}