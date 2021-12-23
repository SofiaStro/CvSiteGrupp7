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

        public ActionResult Index()
        {
            var cv = db.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
            var showCv = cvService.GetCvIndexVeiw(cv.Id);
            return View(showCv);
        }

        // GET: Cv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public void Create(string userName)
        {
            var newCv = cvService.CreateCv(userName);
            db.cvs.Add(newCv);
            db.SaveChanges();
        }

        //GET: Cv/Edit/5
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
                cvService.UpdateImg(model);
                return RedirectToAction("Index");
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
