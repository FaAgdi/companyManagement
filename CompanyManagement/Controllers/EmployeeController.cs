using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyManagement.BLL;
using CompanyManagement.Models;

namespace CompanyManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEmployees()
        {
            try
            {
                EmloyeeBLL Emplist = new EmloyeeBLL();
                List<employee> list = new List<employee>();
                list = Emplist.GetEmployees().ToList();
                var ListReturn = list.Select(x => new {
                    nameEmployee = x.nameEmployee,
                    address = x.address,
                    tel = x.tel,
                    birthday = x.birthday,
                    nameCompany = x.company.nameCompany,
                    nameCategory = x.category.nameCategory,
                    salary = x.salary,
                });
                return Json(ListReturn, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Error", JsonRequestBehavior.AllowGet);

            }
        }
    }
}