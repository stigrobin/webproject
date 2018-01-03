using DatingApp.Models;
using DomainLibrary.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace DatingApp.Controllers
{
    public class UserController : Controller
    {
        private DataContext appDataContext = new DataContext();

        // GET: User
        [Authorize]
        public ActionResult Index(string id)
        {
            
            Profile profile = appDataContext.Profiles
                .FirstOrDefault(x => x.Id == id);
            return View(profile);
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
            bool exists = appDataContext.Profiles.Any(x => x.Id == profile.Id);    
            if(exists)
            {
                Profile existing = appDataContext.Profiles.FirstOrDefault(x => x.Id == profile.Id);
                existing.Presentation = profile.Presentation;
                appDataContext.Entry(existing).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                appDataContext.Profiles.Add(profile);
            }
            appDataContext.SaveChanges();
            return RedirectToAction("Index", new { id = User.Identity.GetUserId() } );
        }

        [Authorize]
        public ActionResult SearchResults(string txtSearch)
        {
            var results = appDataContext.Users
                .Where(x => x.FirstName.Contains(txtSearch) || x.LastName.Contains(txtSearch)).ToList();
            return View(results);
        }
    }
}