using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class CvDBContext : ApplicationDbContext
    {
        public CvDBContext() : base(){ }
        public DbSet<CV> cvs { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<Experience> experiences { get; set; }
        public DbSet<Competence> competences { get; set; }
    }
}
