using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Yucca.Data.DbContext;
using Yucca.Models;
using Yucca.Models.IdentityModels;

namespace Yucca
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class YuccaUserManager : UserManager<YuccaUser,long>
    {
        public YuccaUserManager(IUserStore<YuccaUser,long> store)
            : base(store)
        {
        }

        public static YuccaUserManager Create(IdentityFactoryOptions<YuccaUserManager> options, IOwinContext context) 
        {
            var manager = new YuccaUserManager(new YuccaUserStore(context.Get<YuccaDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<YuccaUser,long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<YuccaUser,long>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<YuccaUser,long>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<YuccaUser,long>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
    // PASS CUSTOM APPLICATION ROLE AND INT AS TYPE ARGUMENTS TO BASE:
    public class YuccaRoleManager : RoleManager<YuccaRole, long>
    {
        // PASS CUSTOM APPLICATION ROLE AND INT AS TYPE ARGUMENTS TO CONSTRUCTOR:
        public YuccaRoleManager(IRoleStore<YuccaRole, long> roleStore)
            : base(roleStore)
        {
        }

        // PASS CUSTOM APPLICATION ROLE AS TYPE ARGUMENT:
        public static YuccaRoleManager Create(
            IdentityFactoryOptions<YuccaRoleManager> options, IOwinContext context)
        {
            return new YuccaRoleManager(
                new YuccaRoleStore(context.Get<YuccaDbContext>()));
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class YuccaSignInManager : SignInManager<YuccaUser,long>
    {
        public YuccaSignInManager(YuccaUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(YuccaUser user)
        {
            return user.GenerateUserIdentityAsync((YuccaUserManager)UserManager);
        }

        public static YuccaSignInManager Create(IdentityFactoryOptions<YuccaSignInManager> options, IOwinContext context)
        {
            return new YuccaSignInManager(context.GetUserManager<YuccaUserManager>(), context.Authentication);
        }
    }
}
