namespace Socializer.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Socializer.DAL.SocializerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Socializer.DAL.SocializerContext";
        }

        protected override void Seed(Socializer.DAL.SocializerContext context)
        {
            List<string> Towns = new List<string>()
            {
                "Cairo", "Alexandria", "Tanta", "Luxor", "Washington", "Sharm El Sheikh"
            };

            Towns.ForEach(t =>
            {
                Town town = new Town()
                {
                    Name = t
                };
                context.Towns.AddOrUpdate(town);
            });
        }
    }
}
