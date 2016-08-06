using System.Data.Entity.ModelConfiguration;
using Yucca.Models.Orders;

namespace Yucca.Data.Configuration.Orders
{
    public class ShoppingCartConfig:EntityTypeConfiguration<ShoppingCart>
    {
        public ShoppingCartConfig()
        {
            HasRequired(a => a.User)
                .WithMany(a => a.ShoppingCarts)
                .HasForeignKey(a => a.UserId);
            HasRequired(a => a.Product)
                .WithMany(a => a.ShoppingCarts)
                .HasForeignKey(a => a.ProductId);
        }
    }
}
