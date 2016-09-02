using Yucca.Models.Products;

namespace Yucca.Models.Orders
{
    public class OrderItem
    {
        #region Ctor

        #endregion

        #region Properties

        public long Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public byte[] RowVersion { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual long ProductId { get; set; }
        public virtual Product Product { get; set; }

        #endregion
    }
}
