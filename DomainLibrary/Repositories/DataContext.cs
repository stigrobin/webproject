using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Repositories
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }


        //DbSet<users>
        public DbSet<Profile> Profiles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasRequired(x => x.Genre)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
            //base.OnModelCreating(modelBuilder);
        }

    }
}
