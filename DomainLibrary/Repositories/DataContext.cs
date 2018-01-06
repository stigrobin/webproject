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

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Friend> Friends { get; set; }

        public static DataContext Create()
        {
            return new DataContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>()
               .HasOptional<ApplicationUser>(s => s.RequestedBy)
               .WithMany()
               .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }



        }
}