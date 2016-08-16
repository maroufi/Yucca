using System.ComponentModel.DataAnnotations;

namespace Yucca.Areas.Admin.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public long Id { get; set; }
        public string PrincipleImage { get; set; }
        public int CommentsCount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalRaters { get; set; }
        public string[] Images { get; set; }
        public bool IsFreeShipping { get; set; }
        public long CategoryId { get; set; }
        public bool IsInStock { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal SellCount { get; set; }
        public int ViewCount { get; set; }
        [DisplayFormat(DataFormatString = "{0:###,###.####}", ApplyFormatInEditMode = true)]
        public long Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal Ratio { get; set; }
        public double? AvrageRate { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal TotalDiscount { get; set; }


    }
}
