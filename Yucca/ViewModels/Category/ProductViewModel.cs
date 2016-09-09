using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yucca.ViewModels.Category
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        [DisplayName("نام کالا")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:###,###.####}", ApplyFormatInEditMode = true)]
        [DisplayName("قیمت")]
        public long Price { get; set; }

        public string ImagePath { get; set; }
    }
}