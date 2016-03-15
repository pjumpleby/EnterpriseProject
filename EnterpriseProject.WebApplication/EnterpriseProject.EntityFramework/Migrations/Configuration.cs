namespace EnterpriseProject.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public abstract class DbContextSeeder<TContext> where TContext : DbContext
    {
        public abstract void Seed(TContext context);
    }

    public sealed class Configuration : DbMigrationsConfiguration<EnterpriseProject.EntityFramework.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        
        protected override void Seed(ApplicationDbContext context)
        {
            // create a new db context seeder.
            DbContextSeeder<ApplicationDbContext> seeder = new ApplicationDbContextSeeder();

            // call the seed method using the given context.
            seeder.Seed(context);



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
