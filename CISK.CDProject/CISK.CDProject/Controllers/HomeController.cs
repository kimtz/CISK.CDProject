using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CISK.CDProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This shop is for all you hungover people.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kim.";

            return View();
        }
    }
}