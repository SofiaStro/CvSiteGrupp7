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

        public MessageService(HttpContext httpContext) { 
            _httpcontext = httpContext;
        }

        public void SaveNewMessage(MessageModel model) {
            using (var context = new MessageDbContext()) {

                var newMessage = new Message()
                {
                    Sender = model.Sender,
                    SendDate = DateTime.Now,
                    Read = false,
                    Content = model.Content,
                    UserName = "xxx"
                };

                context.messages.Add(newMessage);
                context.SaveChanges();
            }

        }
       
    }
}
