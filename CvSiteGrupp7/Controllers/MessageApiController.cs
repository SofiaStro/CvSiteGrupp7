using Data.Contexts;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CvSiteGrupp7.Controllers
{
    [RoutePrefix("api/message")]
    public class MessageApiController : ApiController
    {
        //Använda för att sätta siffran till notiser??

        [HttpGet]
        public List<Message> messages() {
            using (var context = new MessageDbContext()) {
                return context.messages.Where(x => x.Read == false).ToList();
            }
        }
        //[Route("api/message/get/")]
        //[HttpGet]
        //public IHttpActionResult ValidateMessage()
        //{
        //    var repository = new MessageRepository();
        //    var list = repository.GetAllMessages();

        //    if(list == null)
        //    { return BadRequest(); }
        //    return Ok(list);    
          
            
        //}
        
        
    }
}