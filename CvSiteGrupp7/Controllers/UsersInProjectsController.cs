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
            
            var allProjects = projectDb.projects.ToList();
            var allInvolvedProjects = db.usersInProjects.Where(m => m.UserName.Equals(User.Identity.Name)).ToList();

            var allProjectsID = allProjects.Select(m => m.Id).ToList();
            var allInvolvedProjectsID = allInvolvedProjects.Select(m => m.ProjectId).ToList();

            var allExcepts = allProjectsID.Except(allInvolvedProjectsID).ToList();

            List<Project> listOfNotInvolvedProjects = new List<Project>();

            foreach (var id in allExcepts)
            {
                var project = allProjects.Where(m => m.Id == id).FirstOrDefault();
                listOfNotInvolvedProjects.Add(project);
            }

            ViewBag.Projects = new SelectList(listOfNotInvolvedProjects, "Id", "Name");

            return View();
        }

        // POST: UsersInProjects/CreateS
        [HttpPost]
        public ActionResult Create(string SelectedProjectId)
        {
            try
            { 
                usersInProjectsService.CreateUserInProject(Int32.Parse(SelectedProjectId), User.Identity.GetUserId(), User.Identity.Name);

                return RedirectToAction("Index", "Cv");
            }
            catch
            {
                return View();
            }
        }

        //// GET: UsersInProjects/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UsersInProjects/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: UsersInProjects/Delete/5
        public ActionResult Delete(int id)
        {
            var newView = usersInProjectsService.GetDelecteUsersInProjectsView(id);
            return View(newView);
        }

        // POST: UsersInProjects/Delete/5
        [HttpPost]
        public ActionResult Delete(Project model)
        {
            try
            {
                usersInProjectsService.DeleteUsersInProjects(model.Id);

                return RedirectToAction("Index","Cv");
            }
            catch
            {
                return View();
            }
        }
    }
}
