using Socializer.DAL;
using Socializer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Socializer.Controllers
{
    public class NotificationAPIController : ApiController
    {
        private SocializerContext db = new SocializerContext();

        [HttpGet]
        public IHttpActionResult Get(string userId)
        {
            SUser currentLogged = db.Users.Find(userId);
            List<Notification> NotSeen = currentLogged.Notifications.Where(n => n.IsSeen == false).ToList();
            NotSeen.OrderBy(n => n.DateIssued);
            
            if(NotSeen.Count > 0)
            {
                NotSeen[0].IsSeen = true;

                string Message = NotSeen[0].Sender.FullName;

                if(NotSeen[0].Type == NotificiationTypes.FriendRequest)
                {
                    Message += " has sent you a friend request !";
                }
                else
                {
                    Message += " liked your post \"" + NotSeen[0].Post.Caption + "\"";
                }

                db.SaveChanges();

                return Json(Message);
            }


            return Ok("Not Found");
        }
    }
}
