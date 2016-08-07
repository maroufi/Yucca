using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Yucca.Models.Orders;

namespace Yucca.Models.IdentityModels
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class YuccaUser : 
        IdentityUser<long,YuccaUserLogin,YuccaUserRole,YuccaUserClaim>,IUser<long>
    {
        #region Properties

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string AvatarPath { get; set; }
        public virtual DateTime? BirthDay { get; set; }
        public virtual string Ip { get; set; }
        public virtual bool IsBanned { get; set; }
        public virtual DateTime? BannedDate { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual byte[] RowVersion { get; set; }


        #endregion Properties

        #region Navigation Properties
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }


        #endregion
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<YuccaUser,long> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}