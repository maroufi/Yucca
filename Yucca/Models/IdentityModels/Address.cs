using System.Collections.Generic;
using Yucca.Models.Orders;

namespace Yucca.Models.IdentityModels
{
    public class Address
    {

        #region Properties

        public long Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string RemnantAddress { get; set; }
        public string PostCode { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long UserId  { get; set; }
        public virtual YuccaUser User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        #endregion
    }
}
