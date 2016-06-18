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
    public class PostController : Controller
    {
        private SocializerContext db = new SocializerContext();
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeViewModel model, HttpPostedFileBase file)
        {
            SUser currentLogged = db.Users.Find(User.Identity.GetUserId());
            Post post = model.Post;
            post.DatePosted = DateTime.Now;
            post.PostOwner = currentLogged;

            db.Posts.Add(post);
            db.SaveChanges();
            
            if(file != null)
            {
                var path = Server.MapPath("/Images/PostPics/") + post.ID + ".jpg";
                file.SaveAs(path);
                post.ImageURL = "/Images/PostPics/" + post.ID + ".jpg";
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            Post post = db.Posts.Find(id);

            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}