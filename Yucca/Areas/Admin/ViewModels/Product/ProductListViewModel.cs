using System.Collections.Generic;
using Yucca.Models.Orders;

namespace Yucca.Areas.Admin.ViewModels.Product
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> ProductList { get; set; }
    }
}
