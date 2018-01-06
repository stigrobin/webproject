using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApp.ViewModels
{
    public class PostMessageViewModel
    {
        public Profile Profile { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Message Message { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public Friend Friend { get; set; }

    }
}