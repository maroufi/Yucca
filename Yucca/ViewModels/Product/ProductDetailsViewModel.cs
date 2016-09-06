﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yucca.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalRaters { get; set; }
        public bool IsFreeShipping { get; set; }
        public long CategoryId { get; set; }
        public bool IsInStock { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal SellCount { get; set; }
        public int ViewCount { get; set; }
        [DisplayFormat(DataFormatString = "{0:###,###.####}", ApplyFormatInEditMode = true)]
        public long Price { get; set; }
        public string PrincipleImage { get; set; }

        public string[] Images { get; set; }
    }
}