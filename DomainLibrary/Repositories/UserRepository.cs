﻿using DatingApp.Models;
using DomainLibrary.Models;
using System.Linq;

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
