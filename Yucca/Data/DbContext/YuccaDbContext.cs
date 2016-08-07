using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EFSecondLevelCache;
using Microsoft.AspNet.Identity.EntityFramework;
using Yucca.Data.Configuration.Common;
using Yucca.Data.Configuration.Orders;
using Yucca.Data.Configuration.Products;
using Yucca.Data.Configuration.User;
using Yucca.Models.Common;
using Yucca.Models.Orders;
using Yucca.Models.Products;
using System.Data.Entity.Core.Objects;
using System.Web.Mvc.Routing.Constraints;
using Yucca.Models.IdentityModels;

namespace Yucca.Data.DbContext
{
    public class YuccaDbContext: 
        IdentityDbContext<YuccaUser,YuccaRole,long,YuccaUserLogin,YuccaUserRole,YuccaUserClaim>
    {
        public YuccaDbContext()
            : base("YuccaConnection")
        {
        }

        #region DbSets
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderNote> OrderNotes { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<SpecificAttribute> SpecificAttributes { get; set; }
        public DbSet<AttributeOption> AttributeOptions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategorySlide> CategorySlides { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SettingConfig());
            modelBuilder.Configurations.Add(new OrderConfig());
            modelBuilder.Configurations.Add(new OrderItemConfig());
            modelBuilder.Configurations.Add(new OrderNoteConfig());
            modelBuilder.Configurations.Add(new ShoppingCartConfig());
            modelBuilder.Configurations.Add(new SpecificAttributeConfig());
            modelBuilder.Configurations.Add(new AttributeOptionConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new CategorySlideConfig());
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new ProductPictureConfig());
            modelBuilder.Configurations.Add(new AddressConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region UnitOfWorkMethod

        public void AutoDetectChangesEnabled(bool flag = true)
        {
            Configuration.AutoDetectChangesEnabled = flag;
        }

        public void ForceDatabaseInitialize()
        {
            Database.Initialize(true);
        }

        public IList<T> GetRows<T>(string sql, params object[] parameters) where T : class
        {
            return Database.SqlQuery<T>(sql, parameters).ToList();
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Deleted;
        }

        public int SaveAllChanges(bool invalidateCacheDependencies = true)
        {
            var changedEntityNames = GetChangedEntityNames();
            var result = base.SaveChanges();
            if (invalidateCacheDependencies)
            {
                new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
            }
            return result;
        }
        private string[] GetChangedEntityNames()
        {
            return ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added ||
                            x.State == EntityState.Modified ||
                            x.State == EntityState.Deleted)
                .Select(x => ObjectContext.GetObjectType(x.Entity.GetType()).FullName)
                .Distinct()
                .ToArray();
        }
        public Task<int> SaveAllChangesAsync(bool invalidateCacheDependencies = true)
        {
            var changedEntityNames = GetChangedEntityNames();
            var result = base.SaveChangesAsync();
            if (invalidateCacheDependencies)
            {
                new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
            }
            return result;
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        #endregion

        private static void FillAuditFields(YuccaDbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = HttpContext.Current.User.Identity.Name;
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = HttpContext.Current.User.Identity.Name;
                        entry.Entity.ModifiedOn = DateTime.Now;
                        break;
                }
            }

        }
        public static YuccaDbContext Create()
        {
            return new YuccaDbContext();
        }
    }
}