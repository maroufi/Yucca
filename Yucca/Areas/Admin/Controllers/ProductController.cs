using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using EntityFramework.Extensions;
using Yucca.Areas.Admin.ViewModels.Product;
using Yucca.Data.DbContext;
using Yucca.Models.Products;

namespace Yucca.Areas.Admin.Controllers
{
    //[SiteAuthorize(Roles = "admin")]
    [RoutePrefix("Product")]
    [RouteArea("Admin")]
    [Route("{action}")]
    public class ProductController : Controller
    {
        #region Ctor and Dispose 
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
        #endregion

        #region Index
        public ActionResult SelectCategory(int selectType)
        {
            ViewBag.SelectType = selectType;
            return PartialView("_SelectCategory",_dbContext.Categories.Where(a => a.ParentId != null && a.IsDeleted == false).ToList());
        }
        [HttpGet]
        [Route("Index/{categoryId}")]
        public virtual ActionResult Index(long? categoryId)
        {
            if(categoryId==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category = _dbContext.Categories.FirstOrDefault(a => a.Id == categoryId.Value);
            if (category == null) return HttpNotFound();
            var products = _dbContext.Products.Where(a => a.CategoryId == categoryId.Value&&a.Deleted==false).Include(a=>a.Category).ToList();
            List<ProductViewModel> productViewModels = products.Select(product => new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Deleted = product.Deleted,
                NotificationStockMinimum = product.NotificationStockMinimum,
                MetaDescription = product.MetaDescription,
                ViewCount = product.ViewCount,
                SellCount = product.SellCount,
                MetaKeyWords = product.MetaKeyWords,
                IsFreeShipping = product.IsFreeShipping,
                CategoryName = product.Category.Name
            }).ToList();
            return View(productViewModels);
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
        public virtual async Task<ActionResult> Delete(long? id)
        {
            if (id == null) return Content(null);
            _dbContext.Products.Where(a=>a.Id==id).Delete();
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        #endregion

        #region Edit
        [HttpGet]
        [Route("Edit/{id}")]
        public virtual ActionResult Edit(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var product = _dbContext.Products.FirstOrDefault(a => a.Id==id.Value);
            if (product == null) return HttpNotFound();
            var productViewModel = new EditProductViewModel
            {
                CategoryId = product.CategoryId,
                Deleted = product.Deleted,
                Description = product.Description,
                Id = product.Id,
                IsFreeShipping = product.IsFreeShipping,
                Name = product.Name,
                MetaKeyWords = product.MetaKeyWords,
                NotificationStockMinimum = product.NotificationStockMinimum,
                Price = product.Price,
                Stock = product.Stock,
                MetaDescription = product.MetaDescription,
                OldCategoryId = product.CategoryId

            };
            PopulateCategoriesDropDownList(product.CategoryId);
            return View(productViewModel);
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
