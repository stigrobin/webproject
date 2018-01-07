using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Repositories
{
    public class FriendRepository
    {
        DataContext dataContext = new DataContext();

        public bool HasPendingRequest(string visitor, string target)
        {
            bool hasRequested = dataContext.Friends.
                Any(x => x.RequestedBy_Id == visitor && x.RequestedTo_Id == target && x.RequestStatuts == false);

            bool receivedRequest = dataContext.Friends.
                Any(x => x.RequestedBy_Id == target && x.RequestedTo_Id == visitor && x.RequestStatuts == false);

            if (hasRequested || receivedRequest)
            {
                return true;
            }
            else return false;
        }

        public bool IsFriend(string visitor, string target)
        {
            bool hasRequested = dataContext.Friends.
                Any(x => x.RequestedBy_Id == visitor && x.RequestedTo_Id == target && x.RequestStatuts == true);

            bool receivedRequest = dataContext.Friends.
                Any(x => x.RequestedBy_Id == target && x.RequestedTo_Id == visitor && x.RequestStatuts == true);

            if (hasRequested || receivedRequest)
            {
                return true;
            }
            else return false;
        }
    }
}
