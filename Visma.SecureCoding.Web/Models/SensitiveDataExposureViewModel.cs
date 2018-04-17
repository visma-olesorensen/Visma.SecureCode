using System.ComponentModel.DataAnnotations;

namespace Visma.SecureCoding.Web.Models
{
    public class SensitiveDataExposureViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name="Password", ShortName="PW", Description="The password (unhashed)")]
        public string Password { get; set; }

        [Display(Name="Password Result", ShortName="PW Result", Description="The password result")]
        public string PasswordResult { get; set; }
    }
}