using System;
using System.Collections.Generic;
using Yucca.Models.Common;
using Yucca.Models.IdentityModels;

namespace Yucca.Models.Orders
{
    public class Order:BaseEntity
    {
        #region Ctor

        #endregion

        #region Properties
        
        public DateTime? PostedDate { get; set; }
        public OrderStatus Status { get; set; }
        public string TransactionCode { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Price { get; set; }
        public byte[] RowVersion { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long BuyerId { get; set; }
        public virtual YuccaUser Buyer { get; set; }
        public virtual long AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<OrderNote> OrderNotes { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        #endregion
    }
}