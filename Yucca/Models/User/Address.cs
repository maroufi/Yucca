using System.Collections.Generic;
using Yucca.Models.Orders;

namespace Yucca.Models.User
{
    public class Address
    {

        #region Properties

        public virtual long Id { get; set; }
        public virtual string State { get; set; }
        public virtual string City { get; set; }
        public virtual string Street { get; set; }
        public virtual string RemnantAddress { get; set; }
        public virtual string PostCode { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long UserId  { get; set; }
        public virtual Models.User.User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        #endregion
    }
}
