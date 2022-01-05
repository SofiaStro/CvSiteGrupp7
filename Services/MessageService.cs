using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;

namespace Services
{   
    public class MessageService
    {
        public int SaveNewMessage(MessageModel model, string sender)
        {
            try 
            {
                using (var context = new MessageDbContext())
                {

                    var newMessage = new Message()
                    {
                        Sender = sender,
                        SendDate = DateTime.Now,
                        Read = model.Read,
                        Content = model.Content,
                        Receiver = model.Receiver
                    };
                    context.messages.Add(newMessage);
                    context.SaveChanges();
                    return 1;
                }
            }
            catch 
            {
                return 0;
            }
        }

    }
}
