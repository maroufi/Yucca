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
            Property(a => a.Title).HasMaxLength(30);
            Property(a => a.Description).HasMaxLength(300);
            Property(a => a.ImageAltText).HasMaxLength(30);
            Property(a => a.ImagePath).HasMaxLength(300);
            Property(a => a.Link).HasMaxLength(300);
            Property(a => a.HideTransition).HasMaxLength(30);
            Property(a => a.ShowTransition).HasMaxLength(30);
            Property(a => a.Position).HasMaxLength(30);
        }
    }
}
