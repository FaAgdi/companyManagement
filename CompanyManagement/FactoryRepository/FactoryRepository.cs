using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.Repositories;
using CompanyManagement.ViewModel;

namespace CompanyManagement.FactoryRepository
{
    public class FactoryRepository
    {
        public static ILoginRepository loginRep()
        {
            return new LoginRepository();
        }
        public static ILoginRepository login(UserViewModel model)
        {
            return new LoginRepository();
        }
        public static IEmployeeRepository GetEmployeesRep()
        {
            return new EmployeeRepository();
        }
        public static IEmployeeRepository GetEmployees()
        {
            return new EmployeeRepository();
        }

    }
}