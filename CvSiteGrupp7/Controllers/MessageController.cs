using Data.Contexts;
using Shared.Models;
using System.Linq;
using System.Web.Mvc;
using Message = Data.Models.Message;

namespace CvSiteGrupp7.Controllers
{
    public class MessageController : Controller
    {
        private MessageDbContext db = new MessageDbContext();

        // GET: Message/Index
        [Authorize]
        public ActionResult Index()
        {
             var messages = db.messages.ToList();
             return View(messages); 
        }

        // GET: Message/Create
        public ActionResult Create(string receiver)
        {
            var model = new MessageModel();
            model.Receiver = receiver;
            return View(model);
        }

        // GET: Message/Delete/5
        [Authorize]
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
        [Authorize]
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
