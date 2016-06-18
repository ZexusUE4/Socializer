using Socializer.DAL;
using Socializer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Socializer.Controllers
{
    public class LikeController : Controller
    {
        private SocializerContext db = new SocializerContext();

        public ActionResult Likers(int postID)
        {
            Post post = db.Posts.Find(postID);
            List<SUser> likers = new List<SUser>();

            post.Likes.ToList().ForEach(l =>
            {
                likers.Add(db.Users.Find(l.UserID));
            });

            return View(likers);
        }
    }
}