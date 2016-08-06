using Yucca.Models.Products;

namespace Yucca.Models.Orders
{
    public class ShoppingCart
    {
        #region Ctor

        #endregion

        #region Properties
        public virtual long Id { get; set; }
        public virtual int Quantity { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long UserId { get; set; }
        public virtual Models.User.User User { get; set; }
        public virtual long ProductId { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}
