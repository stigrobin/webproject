using DatingApp.Models;
using DatingApp.ViewModels;
using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DatingApp.Controllers
{
    public class HomeController : Controller
    {
        DataContext dataContext = new DataContext();

        public ActionResult Index()
        {
            int count = 0;
            var profiles = dataContext.Profiles.Where(x => x.FileName != null);
            Random random = new Random();
            //int Profilecount = profiles.Count();
            List<string> sources = new List<string>();
            List<Profile> profilesWithPic = new List<Profile>();
            foreach (var item in profiles)
            {
                profilesWithPic.Add(item);

            }
            for (int i = 0; i < 3; i++)
            {
                int randomNumber = random.Next(0, profilesWithPic.Count());
                //var id = profilesWithPic.Where(x => x.ProfileId == randomNumber);
                var pic = (from Profile in profiles where Profile.ProfileId == randomNumber select Profile.Content).First();
                var base64 = Convert.ToBase64String(pic);
                var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                sources.Add(imgSrc);
                count++;
            }
            return View(sources);
        }

        [Authorize]
        public ActionResult EditProfile()
        {
            return View();
        }

    }
}