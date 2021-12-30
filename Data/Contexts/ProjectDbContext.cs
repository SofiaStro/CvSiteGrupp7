using Data.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Data.Contexts
{
    public class ProjectDbContext : DbContext
    {
        internal IEnumerable<object> usersInProjects;

        public ProjectDbContext() : base("DefaultConnection") { }
        public DbSet<Project> projects { get; set; }
    }
}
