using System;
using System.Collections.Generic;
using Yucca.Models.Common;
using Yucca.Models.User;

namespace Yucca.Models.Orders
{
    public class Order:BaseEntity
    {
        #region Ctor

        #endregion

        #region Properties
        
        public virtual DateTime? PostedDate { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual string TransactionCode { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual decimal Price { get; set; }
        public virtual byte[] RowVersion { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long BuyerId { get; set; }
        public virtual Models.User.User Buyer { get; set; }
        public virtual long AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<OrderNote> OrderNotes { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        #endregion
    }
}