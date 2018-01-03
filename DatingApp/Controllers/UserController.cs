using DatingApp.Models;
using DatingApp.ViewModels;
using DomainLibrary.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DatingApp.Controllers
{
    public class UserController : Controller
    {
        private DataContext dataContext = new DataContext();

        // GET: User
        [Authorize]
        public ActionResult Index(string id)
        {
            PostMessageViewModel viewmodel = new PostMessageViewModel();

            viewmodel.Profile = dataContext.Profiles
           .FirstOrDefault(x => x.Id == id);

            if (dataContext.Messages.Count() > 0)
            {
                viewmodel.Messages = dataContext.Messages
                    .Where(x => x.Receiver.ToString() == viewmodel.Profile.Id).ToList();
            }

            return View(viewmodel);
        }

        [Authorize]
        public ActionResult EditProfile()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Profile profile)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            bool exists = dataContext.Profiles.Any(x => x.Id == profile.Id);
            if (exists)
            {
                Profile existing = dataContext.Profiles.FirstOrDefault(x => x.Id == profile.Id);
                existing.Presentation = profile.Presentation;
                dataContext.Entry(existing).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                dataContext.Profiles.Add(profile);
            }
            dataContext.SaveChanges();
            return RedirectToAction("Index", new { id = User.Identity.GetUserId() });
        }

        [Authorize]
        public ActionResult SearchResults(string txtSearch)
        {
            var results = dataContext.Users
                .Where(x => x.FirstName.Contains(txtSearch) || x.LastName.Contains(txtSearch)).ToList();
            return View(results);
        }
    }
}