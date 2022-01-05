using Data.Contexts;
using Data.Models;
using Shared.Models;
using System.Linq;

namespace Services
{
    public class UsersInProjectsService
    {
        private UsersInProjectsDbContext db = new UsersInProjectsDbContext();
        public void CreateUserInProject(int newProjectId, string newUserId, string newUserName)
        {
            var newUserInProject = new UsersInProjects()
            {
                ProjectId = newProjectId,
                UserId = newUserId,
                UserName = newUserName
            };
            db.usersInProjects.Add(newUserInProject);
            db.SaveChanges();
        }

        public void DeleteUsersInProjects(int projectId)
        {
            var UsersInProjects = db.usersInProjects.Where(row => row.ProjectId == projectId);
            foreach(var row in UsersInProjects)
            {
                db.usersInProjects.Remove(row);
            }
            db.SaveChanges();
        }

        public IQueryable<string> GetUserNamesInProject (int projectId)
        {
            var userNamesInProject = from u in db.usersInProjects where u.ProjectId == projectId select u.UserName;
            return userNamesInProject;
        }

        public DelecteUsersInProjectsView GetDelecteUsersInProjectsView(int id)
        {
            ProjectDbContext projectDbContext = new ProjectDbContext();
            var project = projectDbContext.projects.Find(id);
            var newView = new DelecteUsersInProjectsView
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                AddedDate = project.AddedDate
            };
            return newView;
        }
    }
}
