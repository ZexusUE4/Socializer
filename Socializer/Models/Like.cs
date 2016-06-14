using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socializer.Models
{
    public class Like
    {
        public int ID { get; set;}
        public string UserID { get; set; }
        public int PostID { get; set; }

        public virtual SUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}