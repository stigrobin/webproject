using DatingApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Repositories
{
    public class UserRepository
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();

        public string GetID(string username)
        {
            return dataContext.Users.Where(x => x.UserName == username)
                .Select(x => x.Id).ToString();
        }
    }
}
