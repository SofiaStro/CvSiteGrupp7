﻿using Data.Contexts;
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
        private CvDBContext db = new CvDBContext();
        
        // GET: Cv
        public ActionResult Index()
        {
            var cv = db.cvs.Where(row => row.UserName == User.Identity.Name).FirstOrDefault();
            return View(cv);
        }

        // GET: Cv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public void Create(string userName)
        {
            var newCv = new CV()
            {
                UserName = userName,
                Private = true
            };

            db.cvs.Add(newCv);
            db.SaveChanges();
        }

        // GET: Cv/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            CV cv = db.cvs.Find(id);
            if(cv == null)
            {
                return HttpNotFound();
            }
            return View(cv);
        }

        // POST: Cv/Edit/5
        [HttpPost]
        public ActionResult Edit(CV cv)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(cv).State = EntetyState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction View("Index");
            //}
            //return View(cv);
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
