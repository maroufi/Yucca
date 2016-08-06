using System.Data.Entity.ModelConfiguration;
using Yucca.Models.Products;

namespace Yucca.Data.Configuration.Products
{
    public class ProductPictureConfig:EntityTypeConfiguration<ProductPicture>
    {
        public ProductPictureConfig()
        {
            HasRequired(a => a.Product)
                .WithMany(a => a.Pictures)
                .HasForeignKey(a => a.ProductId);
        }
    }
}
