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

        [Route("{id}")]
        public virtual ActionResult Index(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _dbContext.Products
                .Where(a => a.Id == id)
                .Include("ProductImages").Include("Category").FirstOrDefault();
            if (product == null) return HttpNotFound();
            product.ViewCount++;
            var productDetails = new ProductDetailsViewModel
            {
                Id = product.Id,
                IsFreeShipping = product.IsFreeShipping,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Images = product.Pictures.Select(a => a.ImagePath).ToArray(),
                SellCount = product.SellCount,
                ViewCount = product.ViewCount,
                Description = product.Description
            };
            return View(productDetails);
        }
    }
}