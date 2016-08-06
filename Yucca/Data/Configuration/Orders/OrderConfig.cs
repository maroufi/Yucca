using System.Data.Entity.ModelConfiguration;
using Yucca.Models.Orders;

namespace Yucca.Data.Configuration.Orders
{
    public class OrderConfig:EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            HasRequired(a => a.Buyer)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.BuyerId);
            HasRequired(a => a.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(a => a.AddressId);
            HasMany(a => a.OrderItems)
                .WithRequired(a => a.Order)
                .HasForeignKey(a => a.OrderId);
            Property(a => a.RowVersion).IsRowVersion();
            Property(a => a.TransactionCode).HasMaxLength(50);
        }
    }
}
