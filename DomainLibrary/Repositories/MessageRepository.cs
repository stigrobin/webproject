using DatingApp.Models;
using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Repositories
{
    public class MessageRepository
    {
        DataContext dataContext = new DataContext();

        public string GetAuthorFullName(Message message)
        {
            ApplicationUser user = dataContext.Users
                .Where(x => x.Id == message.Author).First();

            string fullName = user.FirstName + " " + user.LastName;
            return fullName;
        }
    }
}
