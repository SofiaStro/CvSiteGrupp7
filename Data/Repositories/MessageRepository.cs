using Data.Contexts;
using Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class MessageRepository
    {
        private readonly MessageDbContext _context;

        public MessageRepository(MessageDbContext context)
        {
            _context = context;
        }
        public MessageRepository()
        { }
        public List<Message> GetAllMessages()
        {
            return _context.messages
                .ToList();
        }
        public bool SetRead(int id)
        {
            var message = _context.messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return false;
            message.Read = true;
            _context.SaveChanges();
            return true;
        }

        public bool SetUnRead(int id)
        {
            var message = _context.messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return false;
            message.Read = false;
            _context.SaveChanges();
            return true;
        }

        public int UnreadMessages()
        {
            var list = _context.messages.Where(x => x.Read == false).ToList();
            return list.Count;
        }


    }
}
