using System.Data.Entity;
using EnterpriseProject.EntityFramework.Migrations;

namespace EnterpriseProject.EntityFramework
{
    public class ApplicationDatabaseInitializer : MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>
    {
        public override void InitializeDatabase(ApplicationDbContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}