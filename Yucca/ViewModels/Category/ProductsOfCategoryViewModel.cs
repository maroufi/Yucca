using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yucca.ViewModels.Category
{
    public class ProductsOfCategoryViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public List<SlideShowViewModel> SlideShows { get; set; }
    }
}