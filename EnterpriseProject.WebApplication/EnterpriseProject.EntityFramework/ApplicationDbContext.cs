using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EnterpriseProject.EntityFramework
{
    [DbConfigurationType(typeof(ApplicationDbConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,
    int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim> 
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}