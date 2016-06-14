using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNet.Identity.EntityFramework;
using Socializer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Socializer.DAL
{
    public class SocializerContext : IdentityDbContext<SUser>
    {
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public SocializerContext()
            : base("SocializerContext", throwIfV1Schema: false)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Added for Identity purpose
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static SocializerContext Create()
        {
            return new SocializerContext();
        }
    }

    public class SocializerContextInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SocializerContext>
    {
        protected override void Seed(SocializerContext context)
        {

        }
    }
}