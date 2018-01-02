using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DomainLibrary.Models;

namespace DatingApp.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }





    }
}