using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManagement.Models;
using CompanyManagement.ViewModel;

namespace CompanyManagement.Repositories
{
    public interface IEmployeeRepository
    {
        List<EmployeeViewModel> GetEmployees();
        string AddEmployee(EmployeeViewModel emp);
        string UpdateEmployee(EmployeeViewModel emp);
        string DeleteEmployee(EmployeeViewModel emp);
    }
}
