using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

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
        }

        public int? HomeTownID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genders Gender { get; set; }
        public MaritalStatuses? MaritalStatus { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ProfilePicURL { get; set; }
        public string AboutMe { get; set; }

        public virtual Town HomeTown { get; set; }
        public virtual ICollection<SUser> Friends { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<SUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}