using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class ProjectDbContext : ApplicationDbContext
    {
        public ProjectDbContext() : base() { }
        public DbSet<Project> projects { get; set; }
    }
}
