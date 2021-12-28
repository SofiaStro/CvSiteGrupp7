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
            public MessageService(HttpContext httpContext)
            {
                _httpcontext = httpContext;
            }

            public int SaveNewMessage(MessageModel model, string sender)
        {
            try {
                using (var context = new MessageDbContext())
                {

                    var newMessage = new Message()
                    {
                        Sender = sender,
                        SendDate = DateTime.Now,
                        Read = model.Read,
                        Content = model.Content,
                        UserName = "xxx"
                    };


                    context.messages.Add(newMessage);
                    context.SaveChanges();
                    return 1;
                }
                }
                catch {
                    return 0;
            }

        }

        //Message message = db.messages.Find(id);
        //db.messages.Remove(message);
        //db.SaveChanges();
        //public bool SetRead(int id)
        //{
        //    var message = db.messages.FirstOrDefault(x => x.Id == id);
        //    if (message == null) return false;
        //    message.Read = true;
        //    db.SaveChanges();
        //    return true;
        //}

        //public bool SetUnRead(int id)
        //{
        //    var message = db.messages.FirstOrDefault(x => x.Id == id);
        //    if (message == null) return false;
        //    message.Read = false;
        //    db.SaveChanges();
        //    return true;
        //}

    }
}
