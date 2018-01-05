using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DomainLibrary.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DatingApp.Models
{

    public class DataContext : IdentityDbContext<ApplicationUser>
    {

        

        public DataContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }



        public static DataContext Create()
        {
            return new DataContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Message> Messages { get; set; }


    }
}