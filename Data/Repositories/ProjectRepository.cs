using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProjectRepository
    {
        private ProjectDbContext db = new ProjectDbContext();
        public Project GetNewestProject()
        {
            Project newestProject = db.projects.OrderByDescending(row => row.AddedDate).FirstOrDefault();
            return newestProject;
        }
    }
}
