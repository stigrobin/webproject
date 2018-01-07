using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApp.ViewModels
{
    public class FriendRequestViewModel
    {
        public ApplicationUser UserModel { get; set; }
        public ApplicationUser TargetModel { get; set; }
    }
}