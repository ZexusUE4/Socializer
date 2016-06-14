using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socializer.Models
{
    public enum NotificiationTypes
    {
        Like,
        FriendRequest,
    }
    public enum NotificationStatuses
    {
        Seen,
        NotSeen,
    }
    public class Notification
    {
        public int ID { get; set; }
        public string SenderID { get; set; }
        public string RecieverID { get; set; }

        public NotificationStatuses Status { get; set; }
        public NotificiationTypes Type { get; set; }
        public DateTime DateIssued { get; set; }

        public virtual SUser Sender { get; set; }
        public virtual SUser Reciever { get; set; }
    }
}