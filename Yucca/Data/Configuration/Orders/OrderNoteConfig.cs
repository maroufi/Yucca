using System.Data.Entity.ModelConfiguration;
using Yucca.Models.Orders;

namespace Yucca.Data.Configuration.Orders
{
    public class OrderNoteConfig:EntityTypeConfiguration<OrderNote>
    {
        public OrderNoteConfig()
        {
            HasRequired(a => a.Order)
                .WithMany(a => a.OrderNotes)
                .HasForeignKey(a => a.OrderId);
            Property(a => a.Note).IsMaxLength();
        }
    }
}
