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
        private ExperienceService experienceService = new ExperienceService();

        private CvDBContext db = new CvDBContext();

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
            Experience existingExperience = db.experiences.Find(id);
            return View(existingExperience);
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Experience model)
        {
            try
            {
                experienceService.UpdateExperience(model);
                return RedirectToAction("Index", "Cv");
            }
            catch
            {
                return View();
            }
        }

        // GET: Experience/Delete/5
        public ActionResult Delete(int id)
        {
            Experience existingExperience = db.experiences.Find(id);
            return View(existingExperience);
        }

        // POST: Experience/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Experience model)
        {
            try
            {
                Experience experience = db.experiences.Find(id);
                db.experiences.Remove(experience);
                db.SaveChanges();
                return RedirectToAction("Index", "Cv");
            }
            catch
            {
                return View();
            }
        }
    }
}
