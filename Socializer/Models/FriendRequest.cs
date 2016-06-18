using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Socializer.Models
{
    public class FriendRequest
    {
        public int ID { get; set; }
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
        public bool IsSeen { get; set; }

        public virtual SUser Sender { get; set; }
        public virtual SUser Receiver { get; set; }
    }
}