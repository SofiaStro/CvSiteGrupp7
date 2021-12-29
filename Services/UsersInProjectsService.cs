using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class UsersInProjectsService
    {
        private UsersInProjectsDbContext db = new UsersInProjectsDbContext();
        private readonly HttpContext _httpcontext;
        public UsersInProjectsService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }

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

        // Raderar de rader i tabellen "UsersInProjects" som har ett specifikt projektId
        public void DeleteUsersInProjects(int projectId)
        {
            var UsersInProjects = db.usersInProjects.Where(row => row.ProjectId == projectId);
            foreach(var row in UsersInProjects)
            {
                db.usersInProjects.Remove(row);
            }
            db.SaveChanges();
        }

        // Raderar de rader i tabellen "UsersInProjects" som har ett specifikt userId
        public void DeleteUsersInProjects(string userId)
        {
            var UsersInProjects = db.usersInProjects.Where(row => row.UserId.Equals(userId));
            foreach (var row in UsersInProjects)
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

        //public GetAllUserInProject(int projectId)
        //{
        //    List<string> UsersInProjects = new List();
        //    foreach(string userName in db.usersInProjects.)
        //    {

        //    }

        //}
    }
}
