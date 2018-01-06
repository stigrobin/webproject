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
    public class FriendController : ApiController
    {
        DataContext dataContext = new DataContext();

        [HttpPost]
        [Route("api/friend/getrequests")]
        public List<ApplicationUser> GetRequests(ApplicationUser user)
        {
            List<ApplicationUser> requesters = new List<ApplicationUser>();

            List<Friend> hasRequested = dataContext.Friends
                .Where(f => f.RequestedTo_Id == user.Id && f.RequestStatuts == false).ToList();
            foreach (var item in hasRequested)
            {
                requesters.Add(dataContext.Users
                    .Single(x => x.Id == item.RequestedBy_Id));
            }

            return requesters;
        }

        [HttpPost]
        [Route("api/friend/acceptrequest")]
        public void AcceptRequest(ApplicationUser user)
        {
            Friend friend = dataContext.Friends
                .Where(x => x.RequestedTo_Id == user.Id).FirstOrDefault();
            friend.RequestStatuts = true;

            dataContext.Entry(friend).State = System.Data.Entity.EntityState.Modified;
            dataContext.SaveChanges();
        }

        [HttpPost]
        [Route("api/friend/declinerequest")]
        public void DeclineRequest(ApplicationUser user)
        {
            Friend friend = dataContext.Friends
                .Where(x => x.RequestedTo_Id == user.Id && x.RequestStatuts == false).First();
            dataContext.Friends.Remove(friend);
            dataContext.SaveChanges();
        }
    }
}

