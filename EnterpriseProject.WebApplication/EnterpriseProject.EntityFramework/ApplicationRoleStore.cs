using Microsoft.AspNet.Identity.EntityFramework;

namespace EnterpriseProject.EntityFramework
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, int, ApplicationUserRole>
    {
        public ApplicationRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}