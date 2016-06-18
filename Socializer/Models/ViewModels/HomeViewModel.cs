using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socializer.Models.ViewModels
{
    public class HomeViewModel
    {
        public Post Post { get; set; }

        public List<Post> PostsFromAll { get; set; }
    }
}