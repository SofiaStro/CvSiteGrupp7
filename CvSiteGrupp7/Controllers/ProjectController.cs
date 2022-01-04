﻿using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Linq;
using System.Web.Mvc;
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
        [Authorize]
        public ActionResult UserIndex()
        {
            var projects = db.projects.Where(row => row.UserName == User.Identity.Name);
            return View(projects);
        }

        // GET: Project
        public ActionResult MainIndex(string searchString)
        {
            var projects = from p in db.projects select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(row => row.Name.Contains(searchString));
            }
            return View(projects);
        }

        // GET: Project/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(ProjectCreateModel projectModel)
        {
            try
            {
                if(ProjectService.ProjectNameExists(projectModel) == false)
                {
                    Project newProject = ProjectService.CreateProject(projectModel, User.Identity.Name);
                    UsersInProjectsService.CreateUserInProject(newProject.Id, User.Identity.GetUserId(), User.Identity.Name);
                    return RedirectToAction("UserIndex");
                }
                else
                {
                    ViewBag.Error = "Ett projekt med detta namn finns redan! Ange ett nytt.";
                    return View();
                }
            }
            catch
            { 
                return View();
            }
        }

        // GET: Project/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Project existingProject = db.projects.Find(id);
            if (existingProject == null)
            {
                return HttpNotFound();
            }
            return View(existingProject); 
        }

        // POST: Project/Edit/5
        [Authorize]
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
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Project existingProject = db.projects.Find(id);
            if (existingProject == null)
            {
                return HttpNotFound();
            }
            return View(existingProject);
        }


        // POST: Project/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                ProjectService.DeleteProject(id);
                UsersInProjectsService.DeleteUsersInProjects(id);
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}    
