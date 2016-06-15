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

            return View(pvm);
        }
    }
}