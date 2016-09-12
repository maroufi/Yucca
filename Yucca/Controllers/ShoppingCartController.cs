using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using EntityFramework.Extensions;
using Yucca.Data.DbContext;
using Yucca.Filter;
using Yucca.Models.Orders;
using Yucca.ViewModels.ShoppingCart;

namespace Yucca.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly YuccaDbContext _dbContext;

        public ShoppingCartController()
        {
            _dbContext=new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }
        [HttpGet]
        //[SiteAuthorize]
        public ActionResult ShowShoppingCart()
        {
            var shoppingCart = _dbContext.ShoppingCarts.Where(a => a.User.UserName == User.Identity.Name).ToList();
            var shoppingCartViewModel = new ShoppingCartListViewModel();
            foreach (var item in shoppingCart)
            {
                shoppingCartViewModel.ShoppingCarts.Add(new ShoppingCartViewModel
                {
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity
                });
            }
            return View(shoppingCartViewModel);
        }
        [HttpPost]
        [SiteAuthorize]
        public virtual async Task<ActionResult> AddToShoppingCart(long? productId, int? quantity=1)
        {
            var user = _dbContext.Users.FirstOrDefault(a => a.UserName == User.Identity.Name);
            if (productId == null||quantity == null || quantity == 0||user==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            var product = _dbContext.Products.FirstOrDefault(a => a.Id == productId);
            if (product == null) return HttpNotFound();
            var cartItem = _dbContext.ShoppingCarts.FirstOrDefault
                (a => a.ProductId == productId && a.UserId== user.Id);

            if (cartItem == null)
            {
                _dbContext.ShoppingCarts.Add(new ShoppingCart
                {
                    UserId = user.Id,
                    Quantity = quantity.Value,
                    ProductId = productId.Value
                });
            }
            else
            {
                cartItem.Quantity += quantity.Value;
            }

            await _dbContext.SaveAllChangesAsync(false);
            return RedirectToAction("ShowShoppingCart");
        }
        [HttpPost]
        [SiteAuthorize]
        public virtual async Task<ActionResult> RemoveFromShoppingCart(long? productId)
        {
            var user = _dbContext.Users.FirstOrDefault(a => a.UserName == User.Identity.Name);
            if (productId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _dbContext.Products.FirstOrDefault(a => a.Id == productId);
            if (product == null) return HttpNotFound();
            await _dbContext.ShoppingCarts.Where(a => a.ProductId == productId && a.UserId == user.Id).DeleteAsync();
            return View("ShowShoppingCart");
        }
    }
}