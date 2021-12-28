using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvSiteGrupp7.Controllers
{
    public class HomeController : Controller
    {
        private HomeService homeService = new HomeService(System.Web.HttpContext.Current);
        public ActionResult Index()
        {
            bool loggedIn = false;
            if (User.Identity.IsAuthenticated) 
            {
                loggedIn = true;
            }
            var showHomeViewModel = homeService.GetHomeViewModel(loggedIn);
            return View(showHomeViewModel);
        }
    }
}