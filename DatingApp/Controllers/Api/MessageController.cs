using DatingApp.Models;
using DatingApp.ViewModels;
using DomainLibrary.Models;
using Microsoft.AspNet.Identity;
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
        public Message Send(PostMessageViewModel viewmodel)
        {

            viewmodel.Message.Author = User.Identity.GetUserId();
            viewmodel.Message.Receiver = dataContext.Profiles
                .Where(x => x.Id == viewmodel.Profile.Id)
                .Select(x => x.ProfileId)
                .FirstOrDefault();
            dataContext.Messages.Add(viewmodel.Message);
            dataContext.SaveChanges();
            return viewmodel.Message;
        }
    }
}
