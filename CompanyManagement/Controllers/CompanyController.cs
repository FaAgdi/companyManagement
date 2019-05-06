using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyManagement.BLL;
using CompanyManagement.Models;

namespace CompanyManagement.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return PartialView();
        }
        public JsonResult GetCompanies()
        {
            try
            {
                CompanyBLL Complist = new CompanyBLL();
                List<company> list = new List<company>();
                list = Complist.GetCompanies().ToList();
                var ListReturn = list.Select(x => new {
                    x.idCompany,
                    x.nameCompany
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