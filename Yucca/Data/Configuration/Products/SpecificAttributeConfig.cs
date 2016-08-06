using System.Data.Entity.ModelConfiguration;
using SpecificAttribute = Yucca.Models.Products.SpecificAttribute;

namespace Yucca.Data.Configuration.Products
{
    public class SpecificAttributeConfig:EntityTypeConfiguration<SpecificAttribute>
    {
        public SpecificAttributeConfig()
        {
            HasMany(a => a.AttributeOptions)
                .WithRequired(a => a.Attribute)
                .HasForeignKey(a => a.AttributeId);
            Property(a => a.Name).HasMaxLength(50);
        }
    }
}
