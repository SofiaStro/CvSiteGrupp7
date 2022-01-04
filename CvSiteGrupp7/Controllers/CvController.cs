using Data.Contexts;
using Shared.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Data.Repositories;
using Microsoft.AspNet.Identity.Owin;
using Services;

namespace CvSiteGrupp7.Controllers
{
    public class CvController : Controller
    {
        private CvDBContext db = new CvDBContext();
        private CvService cvService = new CvService(System.Web.HttpContext.Current);

        //public CvRepository CvRepository
        //{
        //    get { return new CvRepository(HttpContext.GetOwinContext().Get<CvDBContext>()); }
        //}

        // GET: Cv
        //public ActionResult Index()
        //{
        //    var cv = db.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
        //    return View(cv);
        //}

        [Authorize]
        public ActionResult Index()
        {
            var cv = db.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
            var showCv = cvService.GetCvIndexVeiw(cv.Id);
            return View(showCv);
        }

        public ActionResult ShowCvIndex(int id)
        {
            var cv = db.cvs.Find(id);
            var showCv = cvService.GetCvIndexVeiw(cv.Id);
            return View(showCv);
        }

        public ActionResult SearchIndex(string searchString)
        { 
            var cvs = from c in db.cvs select c;
            if (User.Identity.IsAuthenticated)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    cvs = cvs.Where(row => row.Name.Contains(searchString));
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    cvs = cvs.Where(row => row.Name.Contains(searchString) && row.Private == false);
                }
                else
                {
                    cvs = cvs.Where(row => row.Private == false);
                }
            }
            return View(cvs);
        }

        //// GET: Cv/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public void Create(string userName)
        {
            var newCv = cvService.CreateCv(userName);
            db.cvs.Add(newCv);
            db.SaveChanges();
        }

        //GET: Cv/Edit/5
        [Authorize]
        public ActionResult EditInfo(int id)
        {
            //CV cv = db.cvs.Find(id);
            
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            //}
            //if (cv == null)
            //{
            //    return HttpNotFound();
            //}
            var newCvView = cvService.GetEditInfoView(id);
            return View(newCvView);
        }

        // POST: Cv/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditInfo(CvEditInfoView cv)
        {
            try
            {
                //var currentCv = db.cvs.FirstOrDefault(x => x.Id == cv.Id);
                //if (currentCv == null)
                //{
                //    return HttpNotFound();
                //}
                cvService.UpdateInfo(cv);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult EditImg(int id)
        { 
            //CV cv = db.cvs.Find(id);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            //}
            //if (cv == null)
            //{
            //    return HttpNotFound();
            //}

            var newCvView = cvService.GetEditImgView(id);
            return View(newCvView);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditImg(CvEditImgView model)
        {
            try
            {
                //var currentCv = db.cvs.FirstOrDefault(x => x.Id == model.Id);
                //if (currentCv == null)
                //{
                //    return HttpNotFound();
                //}
                
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
        // GET: Cv/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Cv/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
