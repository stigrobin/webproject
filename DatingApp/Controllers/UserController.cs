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

                string myId = User.Identity.GetUserId();

                viewmodel.ApplicationUser = new ApplicationUser
                {
                    UserName = dataContext.Users
                    .Where(x => x.Id == myId).Select(x => x.UserName).Single()
                };

            }
            

            return View(viewmodel);
        }

        [Authorize]
        public ActionResult EditProfile()
        {
            var userId = User.Identity.GetUserId();
            PostMessageViewModel viewModel = new PostMessageViewModel();
            var user = dataContext.Users.Where(x => x.Id == userId).FirstOrDefault();
            var profile = dataContext.Profiles.Where(x => x.Id == userId).FirstOrDefault();
            viewModel.ApplicationUser = user;
            viewModel.Profile = profile;
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(PostMessageViewModel viewModel, HttpPostedFileBase upload, bool searchable)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            var user = dataContext.Users.Find(User.Identity.GetUserId());
            user.Searchable = searchable;
            bool exists = dataContext.Profiles.Any(x => x.Id == user.Id);
            if (exists)
            {
                //modifiera profil om den redan finns
                Profile existing = dataContext.Profiles.FirstOrDefault(x => x.Id == user.Id);
                existing.Presentation = viewModel.Profile.Presentation;
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
                    viewModel.Profile.FileName = Path.GetFileName(upload.FileName);
                    viewModel.Profile.ContentType = upload.ContentType;
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        viewModel.Profile.Content = reader.ReadBytes(upload.ContentLength);
                    }

                }
                dataContext.Profiles.Add(viewModel.Profile);
            }


            dataContext.SaveChanges();
            return RedirectToAction("Index", new { id = User.Identity.GetUserId() });
        }

        [Authorize]
        public ActionResult SearchResults(string txtSearch)
        {
            var results = dataContext.Users
                .Where(x => x.FirstName.Contains(txtSearch) && x.Searchable || x.LastName.Contains(txtSearch) && x.Searchable).ToList();
            return View(results);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddFriend(PostMessageViewModel ViewModel)
        {
            dataContext.Friends.Add(ViewModel.Friend);
            dataContext.SaveChanges();
            return RedirectToAction("Index", new { id = ViewModel.Friend.RequestedTo_Id });
        }
    }
}