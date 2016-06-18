using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Socializer.Models
{
    public enum Genders
    {
        Male,
        Female,

    }

    public enum MaritalStatuses
    {
        Single,
        Engadged,
        Married,
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class SUser : IdentityUser
    {
        public SUser()
        {
            Friends = new HashSet<SUser>();
            Posts = new HashSet<Post>();
            Notifications = new HashSet<Notification>();
        }

        public int? HomeTownID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genders Gender { get; set; }
        [Display(Name ="Marital Status")]
        public MaritalStatuses? MaritalStatus { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true, NullDisplayText = "No date of birth")]
        public DateTime? BirthDate { get; set; }
        public string ProfilePicURL { get; set; }
        public string AboutMe { get; set; }

        [Display(Name="Home Town")]
        public virtual Town HomeTown { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<SUser> Friends { get; set; }

        public string FullName { get
            {
                return FirstName + " " + LastName;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<SUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}