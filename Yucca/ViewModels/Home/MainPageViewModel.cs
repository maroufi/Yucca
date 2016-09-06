using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yucca.ViewModels.Home
{
    public class MainPageViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<ProductPictureViewModel> ProductPictures { get; set; }
    }
}