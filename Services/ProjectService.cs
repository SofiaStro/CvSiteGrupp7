using Data.Contexts;
using Data.Models;
using Shared.Models;
using System.Linq;
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
            };
            db.projects.Add(newProject);
            db.SaveChanges();
            return newProject;
        }

        public void EditProject(Project projectModel)
        {
            var dbProject = db.projects.FirstOrDefault(x => x.Id == projectModel.Id);
            dbProject.Name = projectModel.Name;
            dbProject.Description = projectModel.Description;
            dbProject.AddedDate = projectModel.AddedDate;
            db.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            Project project = db.projects.Find(id);
            db.projects.Remove(project);
            db.SaveChanges();
        }
    }
}
