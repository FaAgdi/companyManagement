using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.Models;

namespace CompanyManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private CompanyManagementEntities _db = new CompanyManagementEntities();
        public List<employee> GetEmployees()
        {
            List<employee> Emplist = new List<employee>();

            //_db.Configuration.ProxyCreationEnabled = false;
            Emplist = (from u in _db.employee select u).ToList();
            


            //Emplist = _db.employee.ToList();
            return Emplist;
        }
    }
}