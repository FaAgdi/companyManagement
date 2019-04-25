using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyManagement.ViewModel
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password :")]
        public string password { get; set; }
        
        [Required(ErrorMessage = "E-mail is required")]
        [Display(Name = "E-mail :")]
        [EmailAddress (ErrorMessage = "The email address is not valid")]
        public string email { get; set; }
    }
}