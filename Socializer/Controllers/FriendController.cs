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

        public ActionResult AcceptFriendRequest(string id1,string id2)
        {
            FriendRequest fr = db.FriendRequests.FirstOrDefault(f => f.ReceiverID == id1 && f.SenderID == id2);

            db.FriendRequests.Remove(fr);
            SUser logged = db.Users.Find(id1);
            SUser other = db.Users.Find(id2);

            logged.Friends.Add(other);
            other.Friends.Add(logged);

            db.SaveChanges();

            return RedirectToAction("ShowProfile", "SUser", new { id = id2 });
        }

        public ActionResult RejectFriendRequest(string id1, string id2)
        {
            FriendRequest fr = db.FriendRequests.FirstOrDefault(f => f.ReceiverID == id1 && f.SenderID == id2);

            db.FriendRequests.Remove(fr);

            db.SaveChanges();

            return RedirectToAction("ShowProfile", "SUser", new { id = id2 });
        }
    }
}