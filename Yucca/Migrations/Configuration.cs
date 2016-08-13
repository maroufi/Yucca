using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Yucca.Models.IdentityModels;
using Yucca.Utility.Security;

namespace Yucca.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data.DbContext;

    internal sealed class Configuration 
        : DbMigrationsConfiguration<Yucca.Data.DbContext.YuccaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Yucca.Data.DbContext.YuccaDbContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }

        private static void InitializeIdentityForEf(YuccaDbContext context)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<YuccaUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<YuccaRoleManager>();
            const string username = "SalmanMaroufi";
            const string email = "salman.maroufi@gmail.com";
            const string password = "Salman@09136861439";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist

            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                // *** INITIALIZE WITH CUSTOM APPLICATION ROLE CLASS:
                role = new YuccaRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(username);
            if (user == null)
            {
                user = new YuccaUser
                {
                    UserName = email,
                    Email = email,
                    AccessFailedCount = 0,
                    PasswordHash = Encryption.EncryptingPassword(password),
                    EmailConfirmed = true,
                    FirstName = "Maroufi",
                    LastName = "Salman"
                };
                userManager.Create(user, password);
                userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
