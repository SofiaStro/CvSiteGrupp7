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
    public class MessageApiController : ApiController
    {
        public MessageRepository messageRepository
        {
            get { return new MessageRepository(Request.GetOwinContext().Get<MessageDbContext>()); }
        }
        MessageService messageService = new MessageService(System.Web.HttpContext.Current);

        [HttpGet]
        [Route("api/message/read/{id}")]
        public IHttpActionResult setRead(int id) {
            try
            {
                var messageOk = messageRepository.SetRead(id);

                if (messageOk) {
                     return Ok();
                }
                
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/message/unread/{id}")]
        public IHttpActionResult setUnRead(int id)
        {
            try
            {
                var messageOk = messageRepository.SetUnRead(id);

                if (messageOk)
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


        //Använda för att sätta siffran till notiser??
        [HttpGet]
        [Route("api/message/countmessages")]
        public int CountUnreadMessages()
        {
            int count = messageRepository.UnreadMessages();
            return count;
        }


        //[HttpGet]
        //[Route("api/message/create")]
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