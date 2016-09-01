using Yucca.Models.Common;

namespace Yucca.Models.Orders
{
    public class OrderNote:BaseEntity
    {
        #region Ctor

        public OrderNote()
        {
        }
        #endregion

        #region Properties
        public string Note { get; set; }
        public bool DisplayToCustomer { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long OrderId { get; set; }
        public virtual Order Order { get; set; }

        #endregion
    }
}
