using System.ComponentModel.DataAnnotations;

namespace Yucca.Areas.Admin.ViewModels.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public bool CompletedAttributes { get; set; }
        public bool AddedImages { get; set; }
        public string Name { get; set; }
        public string PrincipleImagePath { get; set; }
        public bool IsFreeShipping { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal Stock { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal ReserveCount { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal SellCount { get; set; }
        public int ViewCount { get; set; }
        public bool Deleted { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal NotificationStockMinimum { get; set; }
        [DisplayFormat(DataFormatString = "{0:###,###.####}", ApplyFormatInEditMode = true)]
        public long Price { get; set; }
        public bool Notification { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal Ratio { get; set; }
        public double? Rate { get; set; }
        public bool ApplyCategoryDiscount { get; set; }
        public string CategoryName { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal DiscountPercent { get; set; }
    }
}
