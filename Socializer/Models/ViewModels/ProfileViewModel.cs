using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socializer.Models.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            Posts = new List<Post>();
        }

        public SUser User { get; set; } 
        public bool IsLoggedUser { get; set; }
        public bool IsFriend { get; set; }
        public bool IsPendingFriendRequest { get; set; }
        public bool IsWaitingForResponse { get; set; }

        public List<Post> Posts { get; set; }
    }
}