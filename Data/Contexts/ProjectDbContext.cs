using Data.Models;
using System.Data.Entity;

namespace Data.Contexts
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() : base("DefaultConnection") { }
        public DbSet<Project> projects { get; set; }
    }
}
