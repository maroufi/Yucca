using System.Collections.Generic;
using Yucca.Models.Common;
using Yucca.Models.Orders;

namespace Yucca.Models.Products
{
    public class Product:BaseEntity
    {
        #region Ctor

        #endregion

        #region Properties
        public string Name { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public string MetaKeyWords { get; set; }
        public bool IsFreeShipping { get; set; }
        public int Stock { get; set; }
        public int NotificationStockMinimum { get; set; }
        public int SellCount { get; set; }
        public int ViewCount { get; set; }
        public long Price { get; set; }
        public bool Deleted { get; set; }
        #endregion Properties

        #region Navigation Properties

        public virtual long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual long ManufacturerId { get; set; }
        public virtual ICollection<AttributeOption> AttributeOptions { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductPicture> Pictures { get; set; }

        #endregion
    }
}
