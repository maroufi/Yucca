
namespace Yucca.Models.Products
{
    public class ProductPicture
    {
        #region Ctor

        #endregion

        #region Properties

        public virtual long Id { get; set; }
        public virtual string Path { get; set; }
        public virtual bool IsMainPicture { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long ProductId { get; set; }
        public virtual Product Product { get; set; }

        #endregion
    }
}
