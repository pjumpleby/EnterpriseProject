using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace EnterpriseProject.EntityFramework.Migrations
{
    public class ApplicationDbContextSeeder : DbContextSeeder<ApplicationDbContext>
    {
        private const string AdministratorEmail = "administrator@enterpriseproject.com";
        private const string AdministratorUserName = "administrator@enterpriseproject.com";
        private const string AdministratorPassword = "Enterprise2016!";

        private void Log(string message)
        {
            
        }

        private void Log(string message, Exception exception)
        {
            
        }

        public override void Seed(ApplicationDbContext context)
        {
            try
            {
             

                this.Log("Seeding started.");

                // create a new user store for accessing users
                ApplicationUserStore userStore = new ApplicationUserStore(context);

                // create a new user manager for working with users.
                ApplicationUserManager userManager = new ApplicationUserManager(userStore);

                // attempt to find the administrator account by the defaut email address, if the admin account does not exists then this method will return null.
                ApplicationUser administrator = userManager.FindByEmail(AdministratorEmail);

                // if the administrator object is null we need to create the admin account
                if (administrator == null)
                {
                    this.Log("The administrator account does not exist in the database.");

                    // create a new administrator object
                    administrator = new ApplicationUser();

                    administrator.Email = AdministratorEmail;
                    administrator.UserName = AdministratorUserName;

                    IdentityResult createResult = userManager.CreateAsync(administrator, AdministratorPassword).GetAwaiter().GetResult();

                    if (createResult.Succeeded)
                    {
                        this.Log("The default administrator account was created.");
                    }
                    else
                    {
                        this.Log("The default administrator account could not be created.", new Exception(string.Join(Environment.NewLine, createResult.Errors)));
                    }
                }
                else
                {
                    this.Log("The administrator account already exists in the database.");

                    bool administratorPasswordIsDefault = userManager.CheckPasswordAsync(administrator, AdministratorPassword).GetAwaiter().GetResult();

                    // if the admin password is not the default password (i.e. it has been changed) we need to reset it.
                    if (!administratorPasswordIsDefault)
                    {
                        this.Log("The administrator password has been changed from the default and needs to be reset.");

                        // first we need to remove the password from the account.
                        IdentityResult remotePasswordResult = userManager.RemovePasswordAsync(administrator.Id).GetAwaiter().GetResult();

                        if (remotePasswordResult.Succeeded)
                        {
                            this.Log("The current administrator password has been removed.");

                            // now we need to set the password back to the default.
                            IdentityResult addPasswordResult = userManager.AddPasswordAsync(administrator.Id, AdministratorPassword).GetAwaiter().GetResult();

                            if (addPasswordResult.Succeeded)
                            {
                                this.Log("The default administrator password has been set.");
                            }
                            else
                            {
                                this.Log("The default administrator password could not be added.", new Exception(string.Join(Environment.NewLine, addPasswordResult.Errors)));
                            }
                        }
                        else
                        {
                            this.Log("The administrator password could not be removed.", new Exception(string.Join(Environment.NewLine, remotePasswordResult.Errors)));
                        }


                    }
                    else
                    {
                        this.Log("The administrator password is already set to the default value.");
                    }

                }
            }
            catch (Exception exception)
            {
                this.Log("An exception occurred during seeding.", exception);
                throw;
            }
            finally
            {
                this.Log("Seeding complete.");
            }
            
        }
    }
}