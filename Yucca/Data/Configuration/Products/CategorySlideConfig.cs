using System.Data.Entity.ModelConfiguration;
using Yucca.Models.Products;

namespace Yucca.Data.Configuration.Products
{
    public class CategorySlideConfig:EntityTypeConfiguration<CategorySlide>
    {
        public CategorySlideConfig()
        {
            HasRequired(a => a.Category)
                .WithMany(a => a.Slides)
                .HasForeignKey(a => a.CategoryId);
        }
    }
}
