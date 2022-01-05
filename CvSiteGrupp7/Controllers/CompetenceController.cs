using Data.Contexts;
using Data.Models;
using Services;
using Shared.Models;
using System.Linq;
using System.Web.Mvc;

namespace CvSiteGrupp7.Controllers
{
    public class CompetenceController : Controller
    {
        private CompetenceService competenceService = new CompetenceService();
        private CvDBContext db = new CvDBContext();

        // GET: Competence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competence/Create
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

        // GET: Competence/Edit/5
        public ActionResult Edit(int id)
        {
            Competence existingCompetence = db.competences.Find(id);
            return View(existingCompetence);
        }

        // POST: Competence/Edit
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

        // GET: Competence/Delete/5
        public ActionResult Delete(int? id)
        {
            try 
            {
                Competence existingCompetence = db.competences.Find(id);
                return View(existingCompetence);
            }
            catch 
            {
                return View();
            }
         
        }

        // POST: Competence/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
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
