using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socializer.Models.ViewModels
{
    public class ProfileViewModel
    {
        public SUser User { get; set; } 
        public bool IsLoggedUser { get; set; }
        public bool IsFriend { get; set; }
    }
}