namespace Yucca.Areas.Admin.ViewModels.ProductPicture
{
    public class AddProductPicturesViewModel
    {
        public long ProductId { get; set; }
        public string ImagePath { get; set; }
        public bool IsMainPicture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageAltText { get; set; }
        public string Position { get; set; }
    }
}
