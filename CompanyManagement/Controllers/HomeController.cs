using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyManagement.Models;
using CompanyManagement.ViewModel;
using CompanyManagement.BLL;

namespace CompanyManagement.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
            LoginBLL lg = new LoginBLL();
            string result = lg.Login(model);

            if (result == "1")
            {
                Session["LoginID"] = model.email;
                return RedirectToAction("Index","Home");
            }
            else if (result == "0")
            {
                ViewBag.Message = "Password is incorrect !";
                return View(model);
            }
            else
            {
                return View(model);
            }

        }
        public ActionResult Logout()
        {
                Session["LoginID"] = "";
                return RedirectToAction("Login","Home");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }
    }
}