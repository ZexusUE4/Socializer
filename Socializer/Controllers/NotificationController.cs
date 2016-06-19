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
    public class NotificationController : Controller
    {
        private SocializerContext db = new SocializerContext();

        public ActionResult NotificationList()
        {
            SUser currentLogged = db.Users.Find(User.Identity.GetUserId());
            List<Notification> notifs = currentLogged.Notifications.ToList();
            return View(notifs);
        }
    }
}