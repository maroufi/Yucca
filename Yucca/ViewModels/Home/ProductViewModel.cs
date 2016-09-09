using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yucca.ViewModels.Home
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long CategoryId { get; set; }
    }
}