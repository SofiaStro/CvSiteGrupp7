using Data.Contexts;
using Data.Models;
using System.Linq;

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
