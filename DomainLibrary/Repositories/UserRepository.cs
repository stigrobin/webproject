using DatingApp.Models;
using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Repositories
{
    public class UserRepository
    {
        DataContext dataContext = new DataContext();

        public string GetFullName(string id)
        {
            ApplicationUser user = dataContext.Users
                .Where(x => x.Id == id).First();
            string fullName = user.FirstName + " " + user.LastName;
            return fullName;
        }
    }
}
