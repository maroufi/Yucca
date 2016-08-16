using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Yucca.Areas.Admin.ViewModels.ProductPicture;
using Yucca.Data.DbContext;
using Yucca.Filter;

namespace Yucca.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "admin")]
    [RoutePrefix("ProductPicture")]
    [RouteArea("Admin")]
    [Route("{action}")]
    public class ProductPictureController : Controller
    {
        private YuccaDbContext _dbContext;

        public ProductPictureController()
        {
            _dbContext=new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }
        #region Pictures
        [HttpGet]
        [Route("Add/{productId}")]
        public virtual ActionResult Create(long? productId)
        {
            if (productId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _dbContext.Products.First(a => a.Id == productId);
            if (product == null) return HttpNotFound();
            var productPicture = new AddProductPicturesViewModel
            {
                ProductId = product.Id,
            };
            return View(productPicture);
        }
        [HttpPost]
        [Route("Add/{productId}")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Add(AddProductPicturesViewModel viewModel)
        {
            _productImageService.Insert(viewModel);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(MVC.Admin.Product.ActionNames.Index, MVC.Admin.Product.Name);
        }

        [HttpGet]
        [Route("Edit/{productId}")]
        public virtual ActionResult EditPictures(long? productId)
        {
            if (productId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _productService.GetById(productId.Value);
            if (product == null) return HttpNotFound();
            var images = _productImageService.GetImages(productId.Value);
            return System.Web.UI.WebControls.View(images);
        }
        [HttpPost]
        [Route("Edit/{productId}")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> EditPictures(IEnumerable<ProductImage> images)
        {
            _productImageService.Edit(images);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(MVC.Admin.Product.ActionNames.Index, MVC.Admin.Product.Name);
        }
        #endregion
    }
}