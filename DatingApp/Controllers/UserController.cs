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
        public ActionResult Index(int id)
        {
            return View(id);
        }

        [Authorize]
        public ActionResult EditProfile()
        {
            return View();
        }

        [Authorize]
        public ActionResult SearchResults()
        {
          var results = dataContext.Users.ToList();
            return View(results);
        }
    }
}