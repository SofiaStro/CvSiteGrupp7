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

        public int UnreadMessages()
        {
            var list = _context.messages.Where(x => x.Read == false).ToList();
            return list.Count;
        }


    }
}
