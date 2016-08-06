using System.Data.Entity.ModelConfiguration;
using Yucca.Models.Products;

namespace Yucca.Data.Configuration.Products
{
    public class AttributeOptionConfig:EntityTypeConfiguration<AttributeOption>
    {
        public AttributeOptionConfig()
        {
            Property(a => a.Name).HasMaxLength(50);
        }
    }
}
