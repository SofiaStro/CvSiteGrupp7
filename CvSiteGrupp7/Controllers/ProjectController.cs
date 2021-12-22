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

namespace CvSiteGrupp7.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Project
        public ActionResult UserIndex()
        {
                //var projects = context.projects.Where(row => row.UserName == User.Identity.Name);
            var projects = db.projects.ToList();
            return View(projects);
        }

        // GET: Project
        public ActionResult MainIndex()
        {
            var projects = db.projects.ToList();
            return View(projects);
        }


        //// GET: Project/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectCreate projectModel)
        {
            try
            {
                var newProject = new Project()
                {
                    Name = projectModel.Name,
                    Description = projectModel.Description,
                    AddedDate = projectModel.AddedDate,
                    UserName = User.Identity.Name,
                    UserInProject = new List<ApplicationUser>()
                 };
                ApplicationUser CurrentUser = db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                //string user = new User(CurrentUser.UserName);
                //newProject.UserInProject = new List<ApplicationUser>();
                newProject.UserInProject.Add(CurrentUser);
                //ApplicationUser aUser = db.Users.FirstOrDefault();
                //newProject.UserInProject.Add(aUser);
                db.projects.Add(newProject);
                db.SaveChanges();
                return RedirectToAction("UserIndex");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Project existingProject = db.projects.Find(id);
            if(existingProject == null)
            {
                return HttpNotFound();            
            }
            return View(existingProject); 
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            try
            {
               var currentProject = db.projects.FirstOrDefault(x => x.Id == project.Id);
               if (currentProject == null)
               {
                  return HttpNotFound();
               }
               currentProject.Name = project.Name;
               currentProject.Description = project.Description;
               currentProject.AddedDate = project.AddedDate;
               db.SaveChanges();
               return RedirectToAction("UserIndex");
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
            Project existingProject = db.projects.Find(id);
            if (existingProject == null)
            {  
                return HttpNotFound();
            }
            return View(existingProject);
        }


        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Project project = db.projects.Find(id);
                db.projects.Remove(project);
                db.SaveChanges();
                return RedirectToAction("UserIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}    
