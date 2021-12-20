using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CvSiteGrupp7.Controllers
{
    public class MessageApiController : ApiController
    {
        //    [Route("api/message/delete/{id}")]
        //    [HttpGet]
        //    public IHttpActionResult DeleteMessage(int id)
        //    {
        //        //lägga en Delete i ett repository istället?
        //        using (var context = new ApplicationDbContext())
        //        {
        //            var message = context.messages.FirstOrDefault(x => x.Id == id);
        //            if (message == null)
        //            {
        //                return BadRequest();
        //            }

        //            context.messages.Remove(message);
        //            context.SaveChanges();
        //            return Ok();
        //        }
        //    }
    }
}