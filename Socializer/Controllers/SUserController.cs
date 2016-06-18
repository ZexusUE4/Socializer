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
    public class SUserController : Controller
    {
        private SocializerContext db = new SocializerContext();

        public ActionResult ShowProfile(string id)
        {
            SUser user = db.Users.Find(id);
            if (user == null)
                return HttpNotFound();

            SUser currentLogged = db.Users.Find(User.Identity.GetUserId());

            ProfileViewModel pvm = new ProfileViewModel();
            pvm.User = user;
            pvm.IsLoggedUser = currentLogged == user;
            pvm.IsFriend = currentLogged.Friends.Contains(user);
            pvm.Posts = user.Posts.OrderByDescending(p => p.DatePosted).ToList();
            pvm.IsPendingFriendRequest = db.FriendRequests.Where(fr => fr.SenderID == currentLogged.Id && fr.ReceiverID == user.Id).Count() > 0;
            pvm.IsWaitingForResponse = db.FriendRequests.Where(fr => fr.SenderID == user.Id && fr.ReceiverID == currentLogged.Id).Count() > 0; ;
            return View(pvm);
        }

        public ActionResult Edit()
        {
            SUser currentLogged = db.Users.Find(User.Identity.GetUserId());
            RegisterViewModel rvm = new RegisterViewModel()
            {
                AboutMe = currentLogged.AboutMe,
                BirthDate = (DateTime)currentLogged.BirthDate,
                Email = currentLogged.Email,
                FirstName = currentLogged.FirstName,
                LastName = currentLogged.LastName,
                HomeTownID = (int)currentLogged.HomeTownID,
                Gender = currentLogged.Gender,
                MaritalStatus = currentLogged.MaritalStatus,
                PhoneNumber = currentLogged.PhoneNumber
            };

            return View(rvm);
        }

        [HttpPost]
        public ActionResult Edit(RegisterViewModel rvm, HttpPostedFileBase file)
        {
            SUser currentLogged = db.Users.Find(User.Identity.GetUserId());
            currentLogged.AboutMe = rvm.AboutMe;
            currentLogged.BirthDate = rvm.BirthDate;
            currentLogged.Email = rvm.Email;
            currentLogged.FirstName = rvm.FirstName;
            currentLogged.Gender = rvm.Gender;
            currentLogged.HomeTownID = rvm.HomeTownID;
            currentLogged.LastName = rvm.LastName;
            currentLogged.MaritalStatus = rvm.MaritalStatus;
            currentLogged.PhoneNumber = rvm.PhoneNumber;

            if (file != null)
            {
                var path = Server.MapPath("/Images/ProfilePics/") + currentLogged.Id + ".jpg";
                file.SaveAs(path);
                currentLogged.ProfilePicURL = "/Images/ProfilePics/" + currentLogged.Id + ".jpg";
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}