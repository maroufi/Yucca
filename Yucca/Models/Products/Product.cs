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
        public virtual string Name { get; set; }
        public virtual string MetaDescription { get; set; }
        public virtual string Description { get; set; }
        public virtual string MetaKeyWords { get; set; }
        public virtual bool IsFreeShipping { get; set; }
        public virtual int Stock { get; set; }
        public virtual int NotificationStockMinimum { get; set; }
        public virtual int SellCount { get; set; }
        public virtual int ViewCount { get; set; }
        public virtual decimal Price { get; set; }
        public virtual bool Deleted { get; set; }
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
