using Socializer.DAL;
using Socializer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Socializer.Controllers
{
    public class LikeAPIController : ApiController
    {
        private SocializerContext db = new SocializerContext();

        [HttpGet]
        public IHttpActionResult Like(int postID, string userID, string like)
        {
            if (like == "Like")
            {
                Post p = db.Posts.Find(postID);
                p.Likes.Add(new Like()
                {
                    Post = p,
                    UserID = userID
                });

                db.SaveChanges();

                return Ok(p.Likes.Count);
            }
            else
            {
                Post p = db.Posts.Find(postID);
                Like lik = p.Likes.FirstOrDefault(l => l.UserID == userID);

                db.Likes.Remove(lik);

                db.SaveChanges();

                return Ok(p.Likes.Count);
            }

        }
    }
}