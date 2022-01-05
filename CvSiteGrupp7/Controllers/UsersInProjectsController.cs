using Data.Contexts;
using Data.Models;
using Microsoft.AspNet.Identity;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CvSiteGrupp7.Controllers
{
    public class UsersInProjectsController : Controller
    {
        private UsersInProjectsDbContext db = new UsersInProjectsDbContext();
        private UsersInProjectsService usersInProjectsService = new UsersInProjectsService();
        private CvService cvService = new CvService(System.Web.HttpContext.Current);

        // GET: UsersInProjects/Index/5
        public ActionResult Index(int id)
        {
            bool loggedIn = false;
            if (User.Identity.IsAuthenticated)
            {
                loggedIn = true;
            }
            var allUserNamesInProject = usersInProjectsService.GetUserNamesInProject(id);
            var allCvsInProject = cvService.GetCvWithUserName(allUserNamesInProject, loggedIn);
            return View(allCvsInProject);
        }

        // GET: UsersInProjects/Create
        [Authorize]
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

        // POST: UsersInProjects/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(string selectedProjectId)
        {
            try
            { 
                if(!selectedProjectId.Equals("")) { 
                    usersInProjectsService.CreateUserInProject(Int32.Parse(selectedProjectId), User.Identity.GetUserId(), User.Identity.Name);

                    return RedirectToAction("Index", "Cv");
                }
                else
                {
                    ViewBag.Error = "Vänligen välj ett projekt att ansluta till.";
                    return Create();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersInProjects/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var newView = usersInProjectsService.GetDelecteUsersInProjectsView(id);
            return View(newView);
        }

        // POST: UsersInProjects/Delete
        [HttpPost]
        [Authorize]
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
