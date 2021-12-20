using Data.Contexts;
using Data.Models;
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
        // GET: Message
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var messages = context.messages.ToList();
                return View(messages);
            }
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

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(MessageCreate model)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var newMessage = new Data.Models.Message()
                    {
                        Sender = model.Sender,
                        SendDate = DateTime.Now,
                        Read = false,
                        Content = model.Content,
                        UserName = User.Identity.Name
                    };

                    context.messages.Add(newMessage);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
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
            using (var context = new ApplicationDbContext())
            {
                Message existingMessage = context.messages.Find(id);
                if (existingMessage == null)
                {
                    return HttpNotFound();
                }
                return View(existingMessage);

            }
        }
            // POST: Message/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    Message message = context.messages.Find(id);
                    context.messages.Remove(message);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
