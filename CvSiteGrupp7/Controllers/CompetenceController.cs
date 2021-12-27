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
    public class CompetenceController : Controller
    {
        private CompetenceService competenceService = new CompetenceService();

        private CvDBContext db = new CvDBContext();

        // GET: Experience/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experience/Create
        [HttpPost]
        public ActionResult Create(CreateCompetenceView model)
        {
            try
            {
                var cv = db.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
                competenceService.CreateCompetence(model, cv.Id);

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
            Competence existingCompetence = db.competences.Find(id);
            return View(existingCompetence);
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Competence model)
        {
            try
            {
                competenceService.UpdateCompetence(model);
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
            Competence existingCompetence = db.competences.Find(id);
            return View(existingCompetence);
        }

        // POST: Experience/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Competence model)
        {
            try
            {
                Competence competence = db.competences.Find(id);
                db.competences.Remove(competence);
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
