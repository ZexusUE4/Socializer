using Microsoft.AspNet.Identity;
using Socializer.DAL;
using Socializer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Socializer.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        private SocializerContext db = new SocializerContext();

        public ActionResult FriendList()
        {
            SUser currentLogged = db.Users.Find(User.Identity.GetUserId());

            return View(currentLogged.Friends.ToList());
        }

        public ActionResult Unfriend(string id)
        {
            SUser currentLogged = db.Users.Find(User.Identity.GetUserId());
            SUser other = db.Users.Find(id);

            if (other == null)
                return HttpNotFound();

            currentLogged.Friends.Remove(other);
            other.Friends.Remove(currentLogged);

            db.SaveChanges();

            return RedirectToAction("ShowProfile", "SUser", new { id = other.Id });
        }
    }
}