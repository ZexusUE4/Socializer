using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socializer.Models
{
    public class FriendRequest
    {
        public int ID { get; set; }
        public string SenderID { get; set; }
        public string RecieverID { get; set; }

        public virtual SUser Sender { get; set; }
        public virtual SUser Reciever { get; set; }
    }
}