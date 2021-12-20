using Data.Contexts;
using Shared.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvSiteGrupp7.Controllers
{
    public class CvController : Controller
    {
        // GET: Cv
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var cv = context.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
                return View(cv);
            }
        }

        // GET: Cv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cv/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cv/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cv/Edit/5
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

        // GET: Cv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cv/Delete/5
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
