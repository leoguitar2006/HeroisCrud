namespace HeroisCRUD.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HeroisCRUD.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HeroisCRUD.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Universoes.AddOrUpdate(new Models.Universo { Nome = "Marvel" },
                                           new Models.Universo { Nome = "DC" },
                                           new Models.Universo { Nome = "Dark Horse" },
                                           new Models.Universo { Nome = "Image" });
        }
    }
}
