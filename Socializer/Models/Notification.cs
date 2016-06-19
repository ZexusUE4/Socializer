using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string RecieverID { get; set; }
        public string SenderID { get; set; }
        public int? PostID { get; set; }
        public DateTime DateIssued { get; set; }
        public bool IsSeen { get; set; }
        public NotificiationTypes Type { get; set; }

        public virtual SUser Reciever { get; set; }
        public virtual Post Post { get; set; }
        public virtual SUser Sender { get; set; }
       
    }
}