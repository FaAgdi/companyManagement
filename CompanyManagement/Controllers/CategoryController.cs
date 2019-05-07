using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyManagement.BLL;
using CompanyManagement.Models;

namespace CompanyManagement.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return PartialView();
        }
        public JsonResult GetCategories()
        {
            try
            {
                CategoryBLL Complist = new CategoryBLL();
                List<category> list = new List<category>();
                list = Complist.GetCategories().ToList();
                var ListReturn = list.Select(x => new {
                    x.idCategory,
                    x.nameCategory
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