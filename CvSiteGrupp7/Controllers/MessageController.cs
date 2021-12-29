﻿using Data.Contexts;
using Data.Models;
using Services;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Message = Data.Models.Message;

namespace CvSiteGrupp7.Controllers
{
    public class MessageController : Controller
    {
        private MessageDbContext db = new MessageDbContext();

        // GET: Message/Index
        public ActionResult Index()
        {
             var messages = db.messages.ToList();
             return View(messages);
           
        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public ActionResult Create(MessageModel model)
        {

            try
            {
                var sender = "";
                if (User.Identity.IsAuthenticated)
                {
                    sender = User.Identity.Name;
                }
                else
                {
                    sender = model.Sender;
                }
                var service = new MessageService(System.Web.HttpContext.Current);
                service.SaveNewMessage(model, sender);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Message/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Message/Edit/5
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

        // GET: Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
                Message existingMessage = db.messages.Find(id);
                if (existingMessage == null)
                {
                    return HttpNotFound();
                }
                return View(existingMessage);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                    Message message = db.messages.Find(id);
                    db.messages.Remove(message);
                    db.SaveChanges();

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
