using DatingApp.Models;
using DatingApp.ViewModels;
using DomainLibrary.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
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
            if (viewmodel.Profile != null)
            {
                bool profileHasMessages = dataContext.Messages.Any(x => x.Receiver == viewmodel.Profile.ProfileId);
                if (profileHasMessages)
                {
                    viewmodel.Messages = dataContext.Messages
                        .Where(x => x.Receiver == viewmodel.Profile.ProfileId).ToList();
                }
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
        public ActionResult Create(Profile profile, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            bool exists = dataContext.Profiles.Any(x => x.Id == profile.Id);
            if (exists)
            {
                //modifiera profil om den redan finns
                Profile existing = dataContext.Profiles.FirstOrDefault(x => x.Id == profile.Id);
                existing.Presentation = profile.Presentation;
                if (upload != null && upload.ContentLength > 0)
                {
                    existing.FileName = Path.GetFileName(upload.FileName);
                    existing.ContentType = upload.ContentType;
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        existing.Content = reader.ReadBytes(upload.ContentLength);
                    }

                }
                dataContext.Entry(existing).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                //skapa profil om den inte redan finns
                if (upload != null && upload.ContentLength > 0)
                {
                    profile.FileName = Path.GetFileName(upload.FileName);
                    profile.ContentType = upload.ContentType;
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        profile.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    
                }
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