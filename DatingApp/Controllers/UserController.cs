using DatingApp.Models;
using DomainLibrary.Models;
using DomainLibrary.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingApp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext appDataContext = new ApplicationDbContext();
        private DataContext dataContext = new DataContext();

        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult EditProfile()
        {
                return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Profile profile, string txtPresentation)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            profile.Presentation = txtPresentation;
            dataContext.Profiles.Add(profile);
            dataContext.SaveChanges();
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