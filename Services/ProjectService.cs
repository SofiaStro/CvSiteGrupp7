using Data.Contexts;
using Data.Models;
using Data.Repositories;
using Shared.Models;
using System.Linq;
using System.Web;

namespace Services
{
    public class ProjectService
    {
        private ProjectDbContext db = new ProjectDbContext();
        private ProjectRepository projectRepository = new ProjectRepository();
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

        public bool ProjectNameExists(ProjectCreateModel projectModel)
        {
            var allProjectNames = db.projects.Select(row => row.Name).ToList();
            bool doesNameExists = false;
            foreach (var name in allProjectNames)
            {
                if (projectModel.Name.Equals(name))
                {
                    doesNameExists = true;
                }
            }
            return doesNameExists;
        }

        public bool ProjectNameExistsDifferentId(Project project)
        {
            var allProjectsWithDifferentId = db.projects.Where(row => row.Id != project.Id).ToList();
            var allProjectNames = allProjectsWithDifferentId.Select(row => row.Name).ToList();
            bool doesNameExists = false;
            foreach (var name in allProjectNames)
            {
                if (project.Name.Equals(name))
                {
                    doesNameExists = true;
                }
            }
            return doesNameExists;
        }
    }
}
