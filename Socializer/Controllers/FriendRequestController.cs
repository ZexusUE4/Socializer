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
    public class FriendRequestController : Controller
    {
        private SocializerContext db = new SocializerContext();

        public ActionResult AcceptFriendRequest(string id1, string id2)
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

        public ActionResult FriendRequestList()
        {
            SUser currentLogged = db.Users.Find(User.Identity.GetUserId());
            List<FriendRequest> fr = db.FriendRequests.Where(f => f.ReceiverID == currentLogged.Id).ToList();
            return View(fr);
        }

        public ActionResult Accept(int? id)
        {
            if (id == null)
                return HttpNotFound();

            FriendRequest fr = db.FriendRequests.Find(id);

            if (fr == null)
                return HttpNotFound();

            fr.Sender.Friends.Add(fr.Receiver);
            fr.Receiver.Friends.Add(fr.Sender);
            db.FriendRequests.Remove(fr);
            db.SaveChanges();

            return RedirectToAction("FriendRequestList");
        }

        public ActionResult Reject(int? id)
        {
            if (id == null)
                return HttpNotFound();

            FriendRequest fr = db.FriendRequests.Find(id);

            if (fr == null)
                return HttpNotFound();

            db.FriendRequests.Remove(fr);
            db.SaveChanges();

            return RedirectToAction("FriendRequestList");
        }
    }
}