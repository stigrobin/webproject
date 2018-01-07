using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApp.ViewModels
{
    public class ProfileViewModel
    {
        public Profile Profile { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Message Message { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public Friend Friend { get; set; }
        public FriendState FriendState { get; set; }

    }
    [Flags]
    public enum FriendState
    {
        IsNotFriend = 0x01,
        IsPending = 0x02,
        IsFriend = 0x04,
    }
}