using System.Data.Entity.Migrations;
using ClcWorld.Entities.Context;
using ClcWorld.Entities.Migrations.Seed;

namespace ClcWorld.Entities.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ClcWorldContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClcWorldContext context)
        {
            //  This method will be called after migrating to the latest version.

            CarBrandSeed.Seed(context);
            context.SaveChanges();
        }
    }
}