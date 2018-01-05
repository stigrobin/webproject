using DatingApp;
using DatingApp.Models;
using DomainLibrary.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DomainLibrary.Repositories
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            SeedUsers(context);

            context.SaveChanges();

            base.Seed(context);
        }

        private static void SeedUsers(DataContext context)
        {
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            //Users
            var user1 = new ApplicationUser { FirstName = "Tja", LastName = "Tjasson", Email = "tja@tja.se", UserName = "tja@tja.se" };
            var user2 = new ApplicationUser { FirstName = "Hej", LastName = "Hejsson", Email = "hej@hej.se", UserName = "hej@hej.se" };
            var user3 = new ApplicationUser { FirstName = "Yo", LastName = "Yosson", Email = "yo@yo.se", UserName = "yo@yo.se" };

            manager.CreateAsync(user1, "User1!").Wait();
            manager.CreateAsync(user2, "User1!").Wait();
            manager.CreateAsync(user3, "User1!").Wait();
            //Profiles
            var profile1 = new Profile { Presentation = "Jag heter tja, riktigt båtig snubbe om jag får säga det själv",
                Id = user1.Id, Content = GetBytesFromImg("stock.jpg"), ContentType = "image/jpeg", FileName = "stock.jpg" };
            var profile2 = new Profile { Presentation = "Jag heter hej, hemskt mycket hej",
                Id = user2.Id, Content = GetBytesFromImg("stock.jpg"), ContentType = "image/jpeg", FileName = "stock.jpg" };
            var profile3 = new Profile { Presentation = "yo yo! *fantasilös*",
                Id = user3.Id, Content = GetBytesFromImg("stock.jpg"), ContentType = "image/jpeg", FileName = "stock.jpg" };

            context.Profiles.AddRange(new[] { profile1, profile2, profile3 });
            //Messages
        }

        private static byte[] GetBytesFromImg(string imagefilename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            byte[] b = File.ReadAllBytes(path + @"\" + imagefilename);
            return b;
        }
    }
}
