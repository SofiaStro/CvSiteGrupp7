using Data.Contexts;
using Data.Models;
using Data.Repositories;
using Microsoft.AspNet.Identity.Owin;
using Services;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CvSiteGrupp7.Controllers
{
    [RoutePrefix("api/message")]
    public class MessageApiController : ApiController
    {
        //MessageRepository messageRepository = new MessageRepository();
        public MessageRepository messageRepository
        {
            get { return new MessageRepository(Request.GetOwinContext().Get<MessageDbContext>()); }
        }
        //MessageService messageService = new MessageService();

        ////Använda för att sätta siffran till notiser??
        //[HttpGet]
        //public int CountUnreadMessages() {
        //    //using (var context = new MessageDbContext()) {
        //    //    return context.messages.Where(x => x.Read == false).ToList();
        //    //}
        //    int count = messageRepository.UnreadMessages();  
        //    return count;
        //}
        //[Route("api/message/get/")]

        //[HttpPost]
        //[Route("create")]
        //public IHttpActionResult CreateMessage(MessageModel model)
        //{
        //    var succeded = messageService.SaveNewMessage(model);

        //    if (succeded == 0)
        //    { 
        //        return BadRequest(); 
        //    }
        //    else
        //    {
        //        return Ok();
        //    }


        //}


    }
}