using Data.Models;
using System.Data.Entity;

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
