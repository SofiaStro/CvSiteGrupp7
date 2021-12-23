using Data.Contexts;
using Data.Models;
using Services;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvSiteGrupp7.Controllers
{
    public class ExperienceController : Controller
    {
        private ExperienceService experienceService = new ExperienceService(System.Web.HttpContext.Current);

        private CvDBContext db = new CvDBContext();
        // GET: Experience
        public ActionResult Index()
        {
            return View();
        }

        // GET: Experience/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Experience/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experience/Create
        [HttpPost]
        public ActionResult Create(CreateExperienceView model)
        {
            try
            {
                var cv = db.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
                experienceService.CreateExperience(model, cv.Id);

                // TODO: Add insert logic here

                return RedirectToAction("Index", "Cv");
            }
            catch
            {
                return View();
            }
        }

        // GET: Experience/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Experience/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Experience/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Experience/Delete/5
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
