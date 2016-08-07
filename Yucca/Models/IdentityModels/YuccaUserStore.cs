using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Yucca.Models.IdentityModels
{
    public class YuccaUserStore:UserStore<YuccaUser,YuccaRole,long,YuccaUserLogin,YuccaUserRole,YuccaUserClaim>,IUserStore<YuccaUser,long>,IDisposable
    {
        public YuccaUserStore() : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public YuccaUserStore(DbContext context)
            : base(context)
        {
        }
    }
}