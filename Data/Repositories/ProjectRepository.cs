using Data.Contexts;
using Data.Models;
using System.Collections.Generic;
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

        public List<Project> GetListOfProjects(string userName)
        {
            UsersInProjectsDbContext usersInProjectsDbContext = new UsersInProjectsDbContext();
            var userInvolvedInProjects = usersInProjectsDbContext.usersInProjects.Where(m => m.UserName.Equals(userName)).ToList();

            List<Project> listOfProjects = new List<Project>();
            foreach (var element in userInvolvedInProjects)
            {
                var project = db.projects.Where(m => m.Id == element.ProjectId).FirstOrDefault();
                listOfProjects.Add(project);
            }
            return listOfProjects;
        }
    }
}
