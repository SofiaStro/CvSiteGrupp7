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
    public class ProjectService
    {
        private ProjectDbContext db = new ProjectDbContext();
        private readonly HttpContext _httpcontext;
        public ProjectService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }

        public Project CreateProject(ProjectCreateModel projectModel, string userName)
        {
            var newProject = new Project()
            {
                Name = projectModel.Name,
                Description = projectModel.Description,
                AddedDate = projectModel.AddedDate,
                UserName = userName
                //UserInProject = new List<ApplicationUser>()
            };
            //ApplicationUser CurrentUser = db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            //string user = new User(CurrentUser.UserName);
            //newProject.UserInProject = new List<ApplicationUser>();
            //newProject.UserInProject.Add(CurrentUser);
            //ApplicationUser aUser = db.Users.FirstOrDefault();
            return newProject;
        }
    }
}
