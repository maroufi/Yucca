using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Yucca.Models.Common;
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
            base.Seed(context);

            InitializeIdentityForEf(context);
        }

        private static void InitializeIdentityForEf(YuccaDbContext context)
        {
            const string firstName = "Salman";
            const string lastName = "Maroufi";
            const string email = "salman.maroufi@gmail.com";
            const string password = "Salman@09136861439";

            #region Create All Roles
            const string adminRoleName = "Admin";
            const string operatorRoleName = "Operator";
            const string customerRoleName = "Customer";

            var adminRole = context.Roles.FirstOrDefault(a => a.Name == adminRoleName);
            var operatorRole = context.Roles.FirstOrDefault(a => a.Name == operatorRoleName);
            var customerRole = context.Roles.FirstOrDefault(a => a.Name == customerRoleName);
            if (adminRole == null)
            {
                adminRole = new YuccaRole(adminRoleName);
                context.Roles.Add(adminRole);
            }

            if (operatorRole == null)
            {
                operatorRole = new YuccaRole(operatorRoleName);
                context.Roles.Add(operatorRole);

            }
            if (customerRole == null)
            {
                customerRole = new YuccaRole(customerRoleName);
                context.Roles.Add(customerRole);
            }
            #endregion
            var user = context.Users.FirstOrDefault(a => a.UserName == email);
            if (user == null)
            {
                user = new YuccaUser
                {
                    UserName = email,
                    Email = email,
                    AccessFailedCount = 0,
                    PasswordHash = Encryption.EncryptingPassword(password),
                    EmailConfirmed = true,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = "09136861439"
                };
                context.Users.Add(user);
            }
            var firstOrDefault = context.Users.FirstOrDefault(a => a.Id == user.Id);
            if (firstOrDefault != null)
            {
                var rolesForUser = firstOrDefault.Roles.ToList();
                if (rolesForUser.First().RoleId!=adminRole.Id)
                {
                    var userRole = new YuccaUserRole {UserId = user.Id, RoleId = adminRole.Id};
                    context.Users.Find(user.Id).Roles.Add(userRole);
                }
            }
            context.SaveChanges();
        }
    }
}
