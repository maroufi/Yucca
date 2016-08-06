using System.Data.Entity.ModelConfiguration;
using Yucca.Models.Orders;

namespace Yucca.Data.Configuration.Orders
{
    public class OrderItemConfig:EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfig()
        {
            HasRequired(a => a.Product)
                .WithMany(a => a.OrderItems)
                .HasForeignKey(a => a.ProductId);
            Property(a => a.RowVersion).IsRowVersion();
        }
    }
}
