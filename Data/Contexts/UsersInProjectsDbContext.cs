using Data.Models;
using System.Data.Entity;

namespace Data.Contexts
{
    public class UsersInProjectsDbContext : DbContext
    {
        public UsersInProjectsDbContext() : base("DefaultConnection") { }
        public DbSet<UsersInProjects> usersInProjects { get; set; }
    }
}
