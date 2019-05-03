using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.Repositories;
using CompanyManagement.Models;
using CompanyManagement.ViewModel;

namespace CompanyManagement.BLL
{
    public class EmloyeeBLL
    {
        IEmployeeRepository emp;

        public EmloyeeBLL()
        {
           emp = FactoryRepository.FactoryRepository.GetEmployeesRep();
        }
        public List<EmployeeViewModel> GetEmployees()
        {
            return emp.GetEmployees();
        }

        public string AddEmployee(EmployeeViewModel e)
        {
            return emp.AddEmployee(e);
        }
        public string UpdateEmployee(EmployeeViewModel e)
        {
            return emp.UpdateEmployee(e);
        }
        public string DeleteEmployee(EmployeeViewModel e)
        {
            return emp.DeleteEmployee(e);
        }
    }
}