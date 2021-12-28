using Data.Models;
using Data.Repositories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class HomeService
    {
        private CvRepository cvRepository = new CvRepository();
        private ProjectRepository projectRepository = new ProjectRepository();
        private readonly HttpContext _httpcontext;

        public HomeService(HttpContext httpcontext)
        {
            _httpcontext = httpcontext;
        }
        public HomeViewModel GetHomeViewModel(bool loggedIn)
        {
            Project newestProject = projectRepository.GetNewestProject();
            if (newestProject != null)
            {
                var newHomeViewModel = new HomeViewModel
                {
                    ProjectName = newestProject.Name,
                    ProjectDescription = newestProject.Description,
                    ListOfCvs = cvRepository.GetListOfCvs(loggedIn)
                };
                return newHomeViewModel;
            }
            else
            {
                var noProjectsHomeViewModel = new HomeViewModel
                {
                    ProjectName = null,
                    ProjectDescription = null,
                    ListOfCvs = cvRepository.GetListOfCvs(loggedIn)
                };
                return noProjectsHomeViewModel;
            }
        }
    }
}
