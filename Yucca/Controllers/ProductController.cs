using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using Yucca.Data.DbContext;
using Yucca.Filter;
using Yucca.ViewModels.Product;

namespace Yucca.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {
        private readonly YuccaDbContext _dbContext;

        public ProductController()
        {
            _dbContext = new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        [Route("/{productId}")]
        public ActionResult Index(long? productId)
        {
            if (productId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _dbContext.Products
                .Where(a => a.Id == productId)
                .Include(a=>a.Pictures).FirstOrDefault();
            if (product == null) return HttpNotFound();
            product.ViewCount++;
            ViewBag.productDetails = new ProductDetailsViewModel
            {
                Id = product.Id,
                IsFreeShipping = product.IsFreeShipping,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Images = product.Pictures.Select(a => a.ImagePath).ToArray(),
                SellCount = product.SellCount,
                ViewCount = product.ViewCount,
                Description = product.Description,
                PrincipleImage = product.Pictures.FirstOrDefault(a => a.IsMainPicture==true).ImagePath,
                Stock = product.Stock
            };
            return View();
        }
    }
}