﻿using System.Collections.Generic;

namespace Yucca.Models.Products
{
    public class SpecificAttribute
    {
        #region Ctor

        #endregion

        #region Properties

        public long Id { get; set; }
        public string Name { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<AttributeOption> AttributeOptions { get; set; }
        #endregion
    }
}
