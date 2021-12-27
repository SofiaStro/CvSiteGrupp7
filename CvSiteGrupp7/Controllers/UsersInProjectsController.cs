using Data.Contexts;
using Services;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvSiteGrupp7.Controllers
{
    public class UsersInProjectsController : Controller
    {
        private UsersInProjectsDbContext db = new UsersInProjectsDbContext();
        private UsersInProjectsService usersInProjectsService = new UsersInProjectsService(System.Web.HttpContext.Current);

        // GET: UsersInProjects
        public ActionResult Index(int projectId)
        {
            var UsersInProjects = db.usersInProjects.Where(row => row.ProjectId == projectId);
            return View(UsersInProjects);
        }

        // GET: UsersInProjects/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersInProjects/Create
        public ActionResult Create()
        {
            ProjectDbContext projectDb = new ProjectDbContext();
            ViewBag.Projects = new SelectList(projectDb.projects, "Id", "Name");
            return View();
        }

        // POST: UsersInProjects/Create
        [HttpPost]
        public ActionResult Create(UsersInProjectsModel model)
        {
            try
            {
                CvDBContext cvDb = new CvDBContext();
                var cv = cvDb.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
                //educationService.CreateEducation(model, cv.Id);
                //usersInProjectsService.CreateUserInProject()


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersInProjects/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersInProjects/Edit/5
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

        // GET: UsersInProjects/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersInProjects/Delete/5
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
