using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Windows;
using Services;
using Microsoft.AspNet.Identity;

namespace CvSiteGrupp7.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();
        private ProjectService ProjectService = new ProjectService(System.Web.HttpContext.Current);
        private UsersInProjectsService UsersInProjectsService = new UsersInProjectsService(System.Web.HttpContext.Current);

        // GET: Project
        public ActionResult UserIndex()
        {
            var projects = db.projects.Where(row => row.UserName == User.Identity.Name);
            return View(projects);
        }

        // GET: Project
        public ActionResult MainIndex(string searchString)
        {
            var projects = from p in db.projects select p;
            if (!String.IsNullOrEmpty(searchString) && User.Identity.IsAuthenticated)
            {
                projects = projects.Where(row => row.Name.Contains(searchString));
            }
            return View(projects);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectCreateModel projectModel)
        {
            try
            {
                Project newProject = ProjectService.CreateProject(projectModel, User.Identity.Name);
                UsersInProjectsService.CreateUserInProject(newProject.Id, User.Identity.GetUserId(), User.Identity.Name); 
                return RedirectToAction("UserIndex");
            }
            catch
            { 
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int Id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            //}
            Project existingProject = db.projects.Find(Id);
            //if(existingProject == null)
            //{
            //    return HttpNotFound();            
            //}
            return View(existingProject); 
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            try
            {
                ProjectService.EditProject(project);
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int/*?*/ id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            //}
            Project existingProject = db.projects.Find(id);
            //if (existingProject == null)
            //{  
            //    return HttpNotFound();
            //}
            return View(existingProject);
        }


        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Project projectModel)
        {
            try
            {
                ProjectService.DeleteProject(id);
                UsersInProjectsService.DeleteUsersInProject(id);
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}    
