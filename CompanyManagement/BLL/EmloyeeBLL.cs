using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.Repositories;
using CompanyManagement.Models;
namespace CompanyManagement.BLL
{
    public class EmloyeeBLL
    {
        IEmployeeRepository emp;

        public EmloyeeBLL()
        {
           emp = FactoryRepository.FactoryRepository.GetEmployeesRep();
        }
        public List<employee> GetEmployees()
        {
            return emp.GetEmployees();
        }
    }
}