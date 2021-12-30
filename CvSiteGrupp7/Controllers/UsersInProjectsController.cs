using Data.Contexts;
using Data.Models;
using Microsoft.AspNet.Identity;
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
        private CvService cvService = new CvService(System.Web.HttpContext.Current);

        // GET: UsersInProjects
        public ActionResult Index(int projectId)
        {
            bool loggedIn = false;
            if (User.Identity.IsAuthenticated)
            {
                loggedIn = true;
            }
            var allUserNamesInProject = usersInProjectsService.GetUserNamesInProject(projectId);
            var allCvsInProject = cvService.GetCvWithUserName(allUserNamesInProject, loggedIn);
            return View(allCvsInProject);
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
            var projectsName = projectDb.projects.Select(m => m.Name).ToList();
            ViewBag.Projects = new SelectList(projectsName);
            return View();
        }

        // POST: UsersInProjects/CreateS
        [HttpPost]
        public ActionResult Create(string SelectedProjectName)
        {
            try
            {
                ProjectDbContext projectDb = new ProjectDbContext();

                var userID = User.Identity.GetUserId();
                var userName = User.Identity.Name;
                var existingProject = projectDb.projects.Where(m => m.Name.Equals(SelectedProjectName)).FirstOrDefault();
                //from p in projectDb.projects where p.Name.Equals(SelectedProjectName) select p.Id;
                //
                usersInProjectsService.CreateUserInProject(existingProject.Id, userID, userName);
                //CvDBContext cvDb = new CvDBContext();
                //var cv = cvDb.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
                //educationService.CreateEducation(model, cv.Id);
                //usersInProjectsService.CreateUserInProject()


                return RedirectToAction("Index", "Cv");
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
