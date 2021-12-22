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

namespace CvSiteGrupp7.Controllers
{
    public class CvController : Controller
    {
        private CvDBContext db = new CvDBContext();

        //public CvRepository CvRepository
        //{
        //    get { return new CvRepository(HttpContext.GetOwinContext().Get<CvDBContext>()); }
        //}

        // GET: Cv
        public ActionResult Index()
        {
            var cv = db.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
            return View(cv);
        }

        // GET: Cv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public void Create(string userName)
        {
            var newCv = new CV()
            {
                UserName = userName,
                Private = true
            };

            db.cvs.Add(newCv);
            db.SaveChanges();
        }

        // GET: Cv/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            CV cv = db.cvs.Find(id);
            if(cv == null)
            {
                return HttpNotFound();
            }
            return View(cv);
        }

        // POST: Cv/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CV cv)
        {
            try
            {
                var currentCv = db.cvs.FirstOrDefault(x => x.Id == cv.Id);
                if (currentCv == null)
                {
                    return HttpNotFound();
                }

                currentCv.Name = cv.Name;
                currentCv.Address = cv.Address;
                currentCv.Private = cv.Private;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditImg(int id, CvEditImgView model)
        {
            try
            {
                var currentCv = db.cvs.FirstOrDefault(x => x.Id == id);
                if (currentCv == null)
                {
                    return HttpNotFound();
                }

                var filename = model.Image.FileName;
                var filepath = Server.MapPath("~/UplodedImages");
                model.Image.SaveAs(filepath + "/" + filename);
                
                currentCv.ImagePath = filename;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Cv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cv/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
