
namespace Yucca.Models.Products
{
    public class CategorySlide
    {

        #region Properties

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ImageAltText { get; set; }
        public string Link { get; set; }
        public string Position { get; set; }
        public string ShowTransition { get; set; }
        public string HideTransition { get; set; }

        #endregion Properties

        #region Navigation Properties

        public virtual long CategoryId { get; set; }
        public virtual Category Category { get; set; }

        #endregion
    }
}
