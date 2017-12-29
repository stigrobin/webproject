using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatingApp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();

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
        public ActionResult SearchResults(string txtSearch)
        {
            
            var results = dataContext.Users
                .Where(x => x.FirstName.Contains(txtSearch) || x.LastName.Contains(txtSearch)).ToList();
            return View(results);
        }
    }
}