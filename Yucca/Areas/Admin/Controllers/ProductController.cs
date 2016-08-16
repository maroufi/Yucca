using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using EntityFramework.Extensions;
using Yucca.Areas.Admin.ViewModels.Product;
using Yucca.Areas.Admin.ViewModels.ProductAttribute;
using Yucca.Areas.Admin.ViewModels.ProductPicture;
using Yucca.Data.DbContext;
using Yucca.Filter;
using Yucca.Models.Orders;
using Yucca.Models.Products;

namespace Yucca.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "admin")]
    [RoutePrefix("Product")]
    [RouteArea("Admin")]
    [Route("{action}")]
    public class ProductController : Controller
    {
        private readonly YuccaDbContext _dbContext;

        public ProductController()
        {
            _dbContext=new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        #region Index
        [HttpGet]
        [Route("Index/{categoryId}")]
        public virtual ActionResult Index(long? categoryId)
        {
            return View();
        }
        #endregion

        #region Create
        [HttpGet]
        [Route("Add")]
        public virtual ActionResult Create()
        {
            PopulateCategoriesDropDownList(null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Add")]
        public virtual async Task<ActionResult> Create(AddProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = viewModel.Name,
                    CategoryId = viewModel.CategoryId,
                    Deleted = viewModel.Deleted,
                    IsFreeShipping = viewModel.IsFreeShipping,
                    Description = viewModel.Description,
                    MetaDescription = viewModel.MetaDescription,
                    MetaKeyWords = viewModel.MetaKeyWords,
                    Price = viewModel.Price,
                    NotificationStockMinimum = viewModel.NotificationStockMinimum,
                    SellCount = 0,
                    ViewCount = 0,
                    Stock = viewModel.Stock
                };
                _dbContext.Products.Add(product);
                var attributes =
                    _dbContext.SpecificAttributes.AsNoTracking()
                    .Where(a => a.CategoryId == viewModel.CategoryId);
                foreach (var attribute in attributes)
                {
                    _dbContext.AttributeOptions.Add(new AttributeOption
                    {
                        Name = "----",
                        AttributeId = attribute.Id,
                        ProductId = product.Id
                    });
                }
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Create", "Product");
            }
            PopulateCategoriesDropDownList(viewModel.CategoryId);
            if (!ModelState.IsValidField("CategoryId"))
                ModelState.AddModelError("", "گروه محصول را مشخص  کنید");
            return View(viewModel);
        }
        #endregion

        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual async Task<ActionResult> Delete(long? id)
        {
            if (id == null) return Content(null);
            _dbContext.Products.Where(a=>a.Id==id).Delete();
            await _dbContext.SaveChangesAsync();
            return Content("ok");
        }


        #endregion

        #region Edit
        [HttpGet]
        [Route("Edit/{id}")]
        public virtual ActionResult Edit(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _dbContext.Products.Where(a => a.Id.Equals(id)).Select(a => new EditProductViewModel
            {
                CategoryId = a.CategoryId,
                Deleted = a.Deleted,
                Description = a.Description,
                Id = a.Id,
                IsFreeShipping = a.IsFreeShipping,
                Name = a.Name,
                MetaKeyWords = a.MetaKeyWords,
                NotificationStockMinimum = a.NotificationStockMinimum,
                Price = a.Price,
                //PrincipleImagePath = a.PrincipleImagePath,
                Stock = a.Stock,
                MetaDescription = a.MetaDescription,
                OldCategoryId = a.CategoryId

            }).FirstOrDefault();
            if (product == null) return HttpNotFound();
            PopulateCategoriesDropDownList(product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public virtual async Task<ActionResult> Edit(EditProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _dbContext.Products.First(a=>a.Id==viewModel.Id);
                product.Name = viewModel.Name;
                product.CategoryId = viewModel.CategoryId;
                product.Deleted = viewModel.Deleted;
                product.IsFreeShipping = viewModel.IsFreeShipping;
                product.Description = viewModel.Description;
                product.MetaDescription = viewModel.MetaDescription;
                product.MetaKeyWords = viewModel.MetaKeyWords;
                product.Price = viewModel.Price;
                product.NotificationStockMinimum = viewModel.NotificationStockMinimum;
                product.Stock = viewModel.Stock;
                if (viewModel.OldCategoryId != viewModel.CategoryId)
                {
                    _dbContext.AttributeOptions.Where(a => a.ProductId == viewModel.Id).Delete();
                    var attributes = _dbContext.SpecificAttributes.Where(a=>a.CategoryId==viewModel.CategoryId);
                    foreach (var attribute in attributes)
                    {
                        _dbContext.AttributeOptions.Add(new AttributeOption
                        {
                            Name = "----",
                            AttributeId = attribute.Id,
                            ProductId = viewModel.Id
                        });
                    }
                }

                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Product");
            }

            PopulateCategoriesDropDownList(viewModel.CategoryId);
            if (!ModelState.IsValidField("CategoryId"))
                ModelState.AddModelError("", "گروه محصول را مشخص  کنید");
            return View(viewModel);
        }
        #endregion
        void PopulateCategoriesDropDownList(long? selectedId)
        {
            var categories = _dbContext.Categories.AsNoTracking().Where(a => a.ParentId != null).ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name",
                selectedId);
        }
    }
}
