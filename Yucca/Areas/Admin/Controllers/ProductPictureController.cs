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
using Yucca.Models.Products;

namespace Yucca.Areas.Admin.Controllers
{
    //[SiteAuthorize(Roles = "admin")]
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
                ProductId = product.Id
            };
            return View(productPicture);
        }
        [HttpPost]
        [Route("Add/{productId}")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(AddProductPicturesViewModel viewModel)
        {
            var productPicture = new ProductPicture
            {
                Id = viewModel.ProductId,
                ImagePath = viewModel.ImagePath,
                Description = viewModel.Description,
                ImageAltText = viewModel.ImageAltText,
                IsMainPicture = viewModel.IsMainPicture,
                Title = viewModel.Title,
                ProductId = viewModel.ProductId
            };
            _dbContext.ProductPictures.Add(productPicture);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        [Route("Edit/{productId}")]
        public virtual ActionResult Edit(long? productId)
        {
            if (productId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _dbContext.Products.First(a => a.Id == productId);
            if (product == null) return HttpNotFound();
            var editViewModel=new List<EditProductPicturesViewModel>();
            var images = _dbContext.ProductPictures.Where(a=>a.ProductId==productId.Value);
            foreach (var image in images)
            {
                editViewModel.Add(new EditProductPicturesViewModel
                {
                    Id = image.Id,
                    Description = image.Description,
                    ImageAltText = image.ImageAltText,
                    ImagePath = image.ImagePath,
                    IsMainPicture = image.IsMainPicture,
                    Title = image.Title,
                    ProductId = image.ProductId
                });
            }
            return View(editViewModel);
        }
        [HttpPost]
        [Route("Edit/{productId}")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(List<EditProductPicturesViewModel> editViewModel)
        {
            foreach (var item in editViewModel)
            {
                var productPicture = _dbContext.ProductPictures.First(a => a.Id == item.Id);
                if (productPicture != null)
                {
                    productPicture.Description = item.Description;
                    productPicture.ImageAltText = item.ImageAltText;
                    productPicture.ImagePath = item.ImagePath;
                    productPicture.IsMainPicture = item.IsMainPicture;
                    productPicture.Title = item.Title;
                    productPicture.ProductId = item.ProductId;
                }
            }
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Product");
        }
        #endregion
    }
}