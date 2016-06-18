using Microsoft.AspNet.Identity;
using Socializer.DAL;
using Socializer.Models;
using Socializer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Socializer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private SocializerContext db = new SocializerContext();

        public ActionResult Index()
        {
            SUser currentLogged = db.Users.Find(User.Identity.GetUserId());
            List<Post> AllPosts = new List<Post>();

            db.Posts.ToList().ForEach(p =>
            {
                if (p.IsPrivate && (currentLogged.Friends.Contains(p.PostOwner) || p.PostOwner == currentLogged))
                {
                    AllPosts.Add(p);
                }
                else if(!p.IsPrivate)
                    AllPosts.Add(p);
            });

            AllPosts = AllPosts.OrderByDescending(p => p.DatePosted).ToList();

            HomeViewModel hmv = new HomeViewModel();
            hmv.PostsFromAll = AllPosts;

            return View(hmv);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            HashSet<SUser> UserSearch = new HashSet<SUser>(db.Users.Where(u => u.Email == query || u.FirstName == query
                                              || u.LastName == query || u.PhoneNumber == query || u.HomeTown.Name == query).ToList());

            List<Post> posts = db.Posts.Where(p => p.Caption.Contains(query)).ToList();

            posts.ForEach(p =>
           {
               UserSearch.Add(p.PostOwner);
           });

            return View(UserSearch.ToList());
        }
    }
}