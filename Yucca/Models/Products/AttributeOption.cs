using System.Collections.Generic;

namespace Yucca.Models.Products
{
    public class AttributeOption
    {
        #region Ctor

        #endregion

        #region Properties

        public virtual long Id { get; set; }
        public virtual string Name { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long AttributeId { get; set; }
        public virtual SpecificAttribute Attribute { get; set; }
        public virtual long ProductId { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}
