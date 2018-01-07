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
            List<Profile> profiles = dataContext.Profiles.Where(x => x.FileName != null).ToList();
            Random random = new Random();
            //int Profilecount = profiles.Count();
            List<Profile> sources = new List<Profile>();

            //if inga bilder finns
            if (profiles.Count() > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int randomNumber = random.Next(0, profiles.Count());
                    sources.Add(profiles[randomNumber]);
                    count++;
                }
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