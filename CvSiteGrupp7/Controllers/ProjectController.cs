using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvSiteGrupp7.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult UserIndex()
        {
            using (var context = new ApplicationDbContext())
            {
                var projects = context.projects.ToList();
                return View(projects);
            }
        }

        // GET: Project
        public ActionResult MainIndex()
        {
            using (var context = new ApplicationDbContext())
            {
                var projects = context.projects.ToList();
                return View(projects);
            }
        }


        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectCreate model)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var newProject = new Project()
                    {
                        Name = model.Name,
                        Description = model.Description,
                        AddedDate = model.AddedDate,
                        UserName = User.Identity.Name
                    };

                    context.projects.Add(newProject);
                    context.SaveChanges();
                }
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
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

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            using (var context = new ApplicationDbContext())
            {
                Project existingProject = context.projects.Find(id);
                if (existingProject == null)
                {
                    return HttpNotFound();
                }
                return View(existingProject);
            }
        }


        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Project project = context.projects.Find(id);
                    context.projects.Remove(project);
                    context.SaveChanges();
                }
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}    
