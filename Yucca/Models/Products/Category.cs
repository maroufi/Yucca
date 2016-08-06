using System.Collections.Generic;

namespace Yucca.Models.Products
{
    public class Category
    {
        #region Ctor

        #endregion

        #region Properties
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int DisplayOrder { get; set; }
        public virtual string Description { get; set; }
        public virtual string KeyWords { get; set; }
        public virtual bool IsDeleted { get; set; } = false;

        #endregion Properties

        #region Navigation Properties

        public virtual long? ParentId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SpecificAttribute> Attributes { get; set; }
        public virtual ICollection<CategorySlide> Slides { get; set; }
        #endregion
    }
}
