using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class MessageService
    {
        private readonly HttpContext _httpcontext;
        private MessageDbContext db = new MessageDbContext();
        public MessageService(HttpContext httpContext) { 
            _httpcontext = httpContext;
        }

        public void SaveNewMessage(MessageModel model) {
            using (var context = new MessageDbContext()) {

                var newMessage = new Message()
                {
                    Sender = model.Sender,
                    SendDate = DateTime.Now,
                    Read = model.Read,
                    Content = model.Content,
                    UserName = "xxx"
                };
           

                context.messages.Add(newMessage);
                context.SaveChanges();
            }

        }

        //Message message = db.messages.Find(id);
        //db.messages.Remove(message);
        //db.SaveChanges();
        public void SetRead(int id) {
            var dbMessage = db.messages.FirstOrDefault(x => x.Id == id);
            dbMessage.Read = true;
            db.SaveChanges();
        }

        public void SetUnRead(int id)
        {
            var dbMessage = db.messages.FirstOrDefault(x => x.Id == id);
            dbMessage.Read = false;
            db.SaveChanges();
        }

    }
}
