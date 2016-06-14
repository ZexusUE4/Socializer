using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socializer.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string PostOwnerID { get; set; }
        public string Caption { get; set; }
        public string ImageURL { get; set; }
        public bool IsPublic { get; set; }
        public DateTime DatePosted { get; set; }
        
        public virtual SUser PostOwner { get; set; }
        public virtual ICollection<Like> Likes { get; set; }       
    }
}