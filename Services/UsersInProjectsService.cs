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

        //public GetAllUserInProject(int projectId)
        //{
        //    List<string> UsersInProjects = new List();
        //    foreach(string userName in db.usersInProjects.)
        //    {

        //    }

        //}
    }
}
