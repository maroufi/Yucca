using System.Data.Entity.ModelConfiguration;
using Yucca.Models.IdentityModels;

namespace Yucca.Data.Configuration.User
{
    public class AddressConfig:EntityTypeConfiguration<Address>
    {
        public AddressConfig()
        {
            HasRequired(a => a.User)
                .WithMany(a => a.Addresses)
                .HasForeignKey(a => a.UserId);
            HasMany(a=>a.Orders)
                .WithRequired(a=>a.Address)
                .WillCascadeOnDelete(false);
            Property(a => a.City).HasMaxLength(50).IsRequired();
            Property(a => a.State).HasMaxLength(50).IsRequired();
            Property(a => a.Street).HasMaxLength(50).IsRequired();
            Property(a => a.RemnantAddress).HasMaxLength(200).IsOptional();
            Property(a => a.PostCode).HasMaxLength(20).IsRequired();
        }
    }
}
