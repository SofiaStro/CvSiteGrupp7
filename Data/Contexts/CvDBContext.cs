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
        public DbSet<CV> cvs { get; set; }
    }
}
