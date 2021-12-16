using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvSiteGrupp7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Project()
        {
            ViewBag.Message = "Här kan du se alla registrerade projekt.";

            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Message = "Här kan du söka efter registerade CVn.";

            return View();
        }

    }
}