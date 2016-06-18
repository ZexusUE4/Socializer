using Microsoft.AspNet.Identity;
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
    public class FriendRequestAPIController : ApiController
    {
        private SocializerContext db = new SocializerContext();

        public IHttpActionResult Get(string id1, string id2)
        {

            FriendRequest fr = new FriendRequest();
            fr.SenderID = id1;
            fr.ReceiverID = id2;

            db.FriendRequests.Add(fr);
            db.SaveChanges();

            return Ok();
        }
    }
}
