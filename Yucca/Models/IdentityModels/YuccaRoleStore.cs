using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Yucca.Models.IdentityModels
{
    public class YuccaRoleStore:RoleStore<YuccaRole,long,YuccaUserRole>
        ,IQueryableRoleStore<YuccaRole,long>
        ,IRoleStore<YuccaRole,long>
    {
        public YuccaRoleStore()
            :base(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public YuccaRoleStore(DbContext context)
            :base(context)
        {
            
        }
    }
}