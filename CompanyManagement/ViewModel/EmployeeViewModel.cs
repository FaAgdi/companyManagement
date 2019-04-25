using CompanyManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagement.ViewModel
{
    public class EmployeeViewModel
    {
        public int idEmployee { get; set; }
        public string nameEmployee { get; set; }
        public string address { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public string Company { get; set; }
        public string Category { get; set; }
        public Nullable<decimal> salary { get; set; }
    }
}