using System.Collections.Generic;

namespace Yucca.Models.Products
{
    public class Category
    {
        #region Ctor

        #endregion

        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public bool IsDeleted { get; set; } = false;

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
