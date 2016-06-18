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
        }

        protected override void Seed(Socializer.DAL.SocializerContext context)
        {
            return;
            List<string> HomeTowns = new List<string>()
            {
                "Cairo","Alexandria","Tanta","Luxor","Sharm El Sheikh","Hurghada", "Damanhour",
            };

            HomeTowns.ForEach(t =>
            {
                Town town = new Town();
                town.Name = t;
                context.Towns.AddOrUpdate(town);
            });
        }
    }
}
