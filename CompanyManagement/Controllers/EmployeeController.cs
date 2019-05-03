using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CompanyManagement.BLL;
using CompanyManagement.Models;
using CompanyManagement.ViewModel;

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
                List<EmployeeViewModel> list = new List<EmployeeViewModel>();
                list = Emplist.GetEmployees().ToList();
                var ListReturn = list.Select(x => new {
                    x.nameEmployee,
                    x.codeEmployee,
                    x.address,
                    x.tel,
                    x.birthday,
                    x.email,
                    x.company,
                    x.category,
                    x.salary,
                }).ToList();
                return Json(ListReturn, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Error", JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult AddEmployee(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (emp != null)
                    {
                        EmloyeeBLL u = new EmloyeeBLL();
                        u.AddEmployee(emp);
                        return Json(emp, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Invalid Employee", JsonRequestBehavior.AllowGet);
                    }
                }

                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError(string.Empty, "Error");
                }
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys
                                    .Select(key => new { key = key, errors = ModelState[key].Errors})
                                    .ToList()
                            
            });
        }
        public JsonResult UpdateEmployee(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (emp != null)
                    {
                        EmloyeeBLL u = new EmloyeeBLL();
                        u.UpdateEmployee(emp);
                        return Json(emp, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Invalid Employee", JsonRequestBehavior.AllowGet);
                    }
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError(string.Empty, "Error");
                }
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys
                                    .Select(key => new { key = key, errors = ModelState[key].Errors })
                                    .ToList()

            });
        }
        public JsonResult DeleteEmployee(EmployeeViewModel emp)
        {
            try
            {
                if (emp != null)
                {
                    EmloyeeBLL u = new EmloyeeBLL();
                    u.DeleteEmployee(emp);
                    return Json(emp, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Invalid Emp", JsonRequestBehavior.AllowGet);
                }

            }
            catch
            {
                  return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}