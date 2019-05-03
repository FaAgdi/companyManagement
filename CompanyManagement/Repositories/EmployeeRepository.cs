using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyManagement.Models;
using CompanyManagement.ViewModel;

namespace CompanyManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private CompanyManagementEntities _db = new CompanyManagementEntities();
        public List<EmployeeViewModel> GetEmployees()
        {
            List<EmployeeViewModel> Emplist = new List<EmployeeViewModel>();
            try
            {
                _db.Configuration.ProxyCreationEnabled = false;
                Emplist = (from u in _db.employee
                           select new EmployeeViewModel
                           {
                               nameEmployee = u.nameEmployee,
                               codeEmployee = u.codeEmployee,
                               address = u.address,
                               tel = u.tel,
                               birthday = u.birthday,
                               email = u.email,
                               salary = u.salary,
                               company = (from comp in _db.company where u.idCompany == comp.idCompany select comp).FirstOrDefault(),
                               category = (from cat in _db.category where u.idCategory == cat.idCategory select cat).FirstOrDefault(),

                           }
                ).ToList();


                //Emplist = _db.employee.ToList();
                return Emplist;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public string AddEmployee(EmployeeViewModel emp)
        {
            try
            {
                var e = new employee()
                {
                    codeEmployee = emp.codeEmployee,
                    nameEmployee = emp.nameEmployee,
                    address = emp.address,
                    birthday = emp.birthday,
                    email = emp.email,
                    tel = emp.tel,
                    salary = emp.salary,
                    idCompany = emp.company.idCompany,
                    idCategory = emp.category.idCategory
                };
                _db.employee.Add(e);
                _db.SaveChanges();
                return "Employee Updated";
            }
            catch
            {
                throw;
            }

        }

        public string UpdateEmployee(EmployeeViewModel emp)
        {
            try
            {

                employee updatedEmp = (from u in _db.employee
                                       where u.codeEmployee == emp.codeEmployee
                                       select u).FirstOrDefault();
                updatedEmp.nameEmployee = emp.nameEmployee;
                updatedEmp.address = emp.address;
                updatedEmp.birthday = emp.birthday;
                updatedEmp.email = emp.email;
                updatedEmp.tel = emp.tel;
                updatedEmp.salary = emp.salary;
                updatedEmp.idCompany = emp.company.idCompany;
                updatedEmp.idCategory = emp.category.idCategory;
                _db.SaveChanges();
                return "Employee Updated";
            }
            catch
            {
                throw;
            }
        }
        public string DeleteEmployee(EmployeeViewModel emp)
        {
            try
            {
                employee deletedEmp = (from u in _db.employee
                                       where u.codeEmployee == emp.codeEmployee
                                       select u).FirstOrDefault();
                _db.employee.Remove(deletedEmp);
                _db.SaveChanges();
                return "Employee Deleted";
            }
            catch
            {
                throw;
            }
        }
    }
}