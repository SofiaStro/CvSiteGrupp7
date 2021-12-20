using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace CvSiteGrupp7.Controllers
{
    [RoutePrefix("api/project")]
    public class BookApiController : ApiController
    {
        public BookRepository BookRepository
        {
            get { return new BookRepository(Request.GetOwinContext().Get<BookContext>()); }
        }

        [HttpPost]   // Anropa med $.ajax eller $.post
        [Route("delete")] // api/book/delete
        public IHttpActionResult Delete(ProjectDelete model)
        {
            try
            {
                var OKDelete = BookRepository.DeleteProject(model.ProjectId);
                if (OKDelete)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}