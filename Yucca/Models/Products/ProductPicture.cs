
namespace Yucca.Models.Products
{
    public class ProductPicture
    {
        #region Properties

        public long Id { get; set; }
        public bool IsMainPicture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ImageAltText { get; set; }
        #endregion Properties

        #region Navigation Properties

        public virtual long ProductId { get; set; }
        public virtual Product Product { get; set; }

        #endregion
    }
}
