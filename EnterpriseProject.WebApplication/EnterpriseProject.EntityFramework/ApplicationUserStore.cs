using Microsoft.AspNet.Identity.EntityFramework;

namespace EnterpriseProject.EntityFramework
{
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, int,
        ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }

       
    }
}