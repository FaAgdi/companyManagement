//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanyManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class employee
    {
        public employee()
        {
            this.history = new HashSet<history>();
        }
    
        public int idEmployee { get; set; }
        public string nameEmployee { get; set; }
        public string address { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public Nullable<int> idCompany { get; set; }
        public Nullable<int> idCategory { get; set; }
        public Nullable<decimal> salary { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
    
        public virtual category category { get; set; }
        public virtual company company { get; set; }
        public virtual ICollection<history> history { get; set; }
    }
}
