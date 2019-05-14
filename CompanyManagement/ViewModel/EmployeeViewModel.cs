using CompanyManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyManagement.ViewModel
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "Code Employee is required")]
        public string codeEmployee { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        public string nameEmployee { get; set; }
        public string address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string tel { get; set; }
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "The E-mail is not valid")]
        public string email { get; set; }
        public int IdCompany { get; set; }
        public int IdCategory { get; set; }
        [Required(ErrorMessage = "Salary required")]
        public decimal salary { get; set; }
        [Required(ErrorMessage = "Birthday required")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> birthday { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public virtual category category { get; set; }
        [Required(ErrorMessage = "Company is required")]
        public virtual company company { get; set; }
        public virtual ICollection<history> history { get; set; }


    }
}