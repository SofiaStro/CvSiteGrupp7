using Data.Contexts;
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
            return View();
        }

        // POST: UsersInProjects/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
