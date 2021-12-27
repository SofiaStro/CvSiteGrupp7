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
    public class EducationController : Controller
    {
        private EducationService educationService = new EducationService();

        private CvDBContext db = new CvDBContext();

        // GET: Experience/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experience/Create
        [HttpPost]
        public ActionResult Create(CreateEducationView model)
        {
            try
            {
                var cv = db.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
                educationService.CreateEducation(model, cv.Id);

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
            Education existingEducation = db.educations.Find(id);
            return View(existingEducation);
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Education model)
        {
            try
            {
                educationService.UpdateEducation(model);
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
            Education existingEducation = db.educations.Find(id);
            return View(existingEducation);
        }

        // POST: Experience/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Education model)
        {
            try
            {
                Education education = db.educations.Find(id);
                db.educations.Remove(education);
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
