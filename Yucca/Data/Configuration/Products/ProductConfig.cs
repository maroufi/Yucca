using System.Data.Entity.ModelConfiguration;
using Yucca.Models.Products;

namespace Yucca.Data.Configuration.Products
{
    public class ProductConfig:EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            HasMany(a => a.AttributeOptions)
                .WithMany(a => a.Products)
                .Map(map =>
                {
                    map.MapLeftKey("ProductId");
                    map.MapRightKey("AttributeId");
                    map.ToTable("Product_AttributeOption");
                });
        }
    }
}
