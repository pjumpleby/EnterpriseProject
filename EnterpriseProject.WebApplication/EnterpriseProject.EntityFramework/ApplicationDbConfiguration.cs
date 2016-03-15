using System.Data.Entity;

namespace EnterpriseProject.EntityFramework
{
    public class ApplicationDbConfiguration : DbConfiguration
    {
        public ApplicationDbConfiguration()
        {
            this.SetDatabaseInitializer(new ApplicationDatabaseInitializer ());
        }
    }
}