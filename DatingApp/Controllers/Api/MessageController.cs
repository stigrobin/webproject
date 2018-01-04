using DatingApp.Models;
using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatingApp.Controllers.Api
{
    public class MessageController : ApiController
    {
        DataContext dataContext = new DataContext();

        [HttpPost]
        public Message PostMessage(Message message)
        {
            dataContext.Messages.Add(message);
            return message;
        }
    }
}
