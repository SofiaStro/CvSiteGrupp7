using Data.Contexts;
using Shared.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Services;

namespace CvSiteGrupp7.Controllers
{
    public class CvController : Controller
    {
        private CvDBContext db = new CvDBContext();
        private CvService cvService = new CvService(System.Web.HttpContext.Current);

        // GET: Cv/Index
        [Authorize]
        public ActionResult Index()
        {
            var cv = db.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
            var showCv = cvService.GetCvIndexVeiw(cv.Id);
            return View(showCv);
        }

        // GET: Cv/ShowCvIndex/5
        public ActionResult ShowCvIndex(int id)
        {
            var cv = db.cvs.Find(id);
            var showCv = cvService.GetCvIndexVeiw(cv.Id);
            return View(showCv);
        }

        // GET: Cv/SearchIndex
        public ActionResult SearchIndex(string searchString)
        { 
            var cvs = from c in db.cvs select c;
            if (User.Identity.IsAuthenticated)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    cvs = cvs.Where(rows => rows.Name.Contains(searchString));
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    cvs = cvs.Where(rows => rows.Name.Contains(searchString) && rows.Private == false);
                }
                else
                {
                    cvs = cvs.Where(rows => rows.Private == false);
                }
            }
            return View(cvs);
        }

        //Anropas från AccountController så att ett CV skapas automatiskt när en användare registreras.
        public void Create(string userName)
        {
            var newCv = cvService.CreateCv(userName);
            db.cvs.Add(newCv);
            db.SaveChanges();
        }

        //GET: Cv/EditInfo/5
        [Authorize]
        public ActionResult EditInfo(int id)
        {
            var newCvView = cvService.GetEditInfoView(id);
            return View(newCvView);
        }

        // POST: Cv/EditInfo
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditInfo(CvEditInfoView cv)
        {
            try
            {
                cvService.UpdateInfo(cv);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cv/EditImg/5
        [Authorize]
        public ActionResult EditImg(int id)
        { 
            var newCvView = cvService.GetEditImgView(id);
            return View(newCvView);
        }

        // POST: Cv/EditImg
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditImg(CvEditImgView model)
        {
            try
            {             
                if (model.Image != null) { 
                    cvService.UpdateImg(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Vänligen välj en ny bild.";
                    var newCvView = cvService.GetEditImgView(model.Id);
                    return View(newCvView);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
