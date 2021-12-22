using Data.Contexts;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CvSiteGrupp7.Controllers
{
    public class MessageApiController : ApiController
    { 
        [Route("api/message/get/")]
        [HttpGet]
        public IHttpActionResult ValidateMessage()
        {
            var repository = new MessageRepository();
            var list = repository.GetAllMessages();

            if(list == null)
            { return BadRequest(); }
            return Ok(list);    
          
            
        }
    }
}