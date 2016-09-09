using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yucca.Models.IdentityModels;

namespace Yucca.ViewModels.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
    }
}