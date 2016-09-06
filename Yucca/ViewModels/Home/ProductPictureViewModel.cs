using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yucca.ViewModels.Home
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public bool IsMainPicture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ImageAltText { get; set; }
        public long ProductId { get; set; }
    }
}