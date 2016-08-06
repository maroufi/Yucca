
namespace Yucca.Models.Products
{
    public class CategorySlide
    {
        #region Ctor

        #endregion

        #region Properties

        public virtual long Id { get; set; }
        public virtual string Path { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long CategoryId { get; set; }
        public virtual Category Category { get; set; }

        #endregion
    }
}
