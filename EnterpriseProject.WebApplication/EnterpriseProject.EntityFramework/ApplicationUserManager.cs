using Microsoft.AspNet.Identity;

namespace EnterpriseProject.EntityFramework
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
        }

    }



}