using System.ComponentModel.DataAnnotations;

namespace Yucca.Areas.Admin.ViewModels.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public string MetaKeyWords { get; set; }
        public bool IsFreeShipping { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public int Stock { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public int NotificationStockMinimum { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public int SellCount { get; set; }
        public int ViewCount { get; set; }
        [DisplayFormat(DataFormatString = "{0:###,###.####}", ApplyFormatInEditMode = true)]
        public long Price { get; set; }
        public bool Deleted { get; set; }
        public string CategoryName { get; set; }
    }
}
