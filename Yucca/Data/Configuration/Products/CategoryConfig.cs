using System.Data.Entity.ModelConfiguration;
using Yucca.Models.Products;

namespace Yucca.Data.Configuration.Products
{
    public class CategoryConfig:EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            HasMany(a => a.ChildCategories)
                .WithOptional(a => a.ParentCategory)
                .HasForeignKey(a => a.ParentId)
                .WillCascadeOnDelete(false);
            HasMany(a => a.Products)
                .WithRequired(a => a.Category)
                .HasForeignKey(a => a.CategoryId);
            HasMany(a => a.Attributes)
                .WithRequired(a => a.Category)
                .HasForeignKey(a => a.CategoryId)
                .WillCascadeOnDelete(false);
            Property(a => a.Description).HasMaxLength(200);
        }
    }
}
