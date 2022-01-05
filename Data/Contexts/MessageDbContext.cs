using Data.Models;
using System.Data.Entity;

namespace Data.Contexts
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext() : base("DefaultConnection") { }
        public DbSet<Message> messages { get; set; }
    }

}
