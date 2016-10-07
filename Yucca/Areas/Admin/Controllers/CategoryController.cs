using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using EntityFramework.Extensions;
using Yucca.Areas.Admin.ViewModels.Category;
using Yucca.Data.DbContext;
using Yucca.Filter;
using Yucca.Models.Products;

namespace Yucca.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "Admin")]
    [RouteArea("Admin")]
    [RoutePrefix("Category")]
    [Route("{action}")]
    public class CategoryController : Controller
    {
        private readonly YuccaDbContext _dbContext;

        public CategoryController()
        {
            _dbContext = new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _dbContext.Dispose();
            base.Dispose(disposing);
        }

        #region Method
        private IEnumerable<CategoryViewModel> GetDataTable(out int total, string term, int page, int count = 10)
        {
            var selectedCategories = _dbContext.Categories.AsNoTracking().OrderBy(a => a.Id).AsQueryable();
            if (!string.IsNullOrEmpty(term))
            {
                selectedCategories = selectedCategories.Where(a => a.Name.Contains(term));
            }

            var totalQuery = selectedCategories.FutureCount();
            var query = selectedCategories.Skip((page - 1)*count).Take(count).Select(a => new CategoryViewModel
            {
                Name = a.Name,
                Id = a.Id
            }).Future();
            total = totalQuery.Value;
            var categories = query.ToList();
            return categories;
        }

        #endregion

        #region Category

        #region Create

        [HttpGet]
        public virtual ActionResult Create()
        {
            ViewBag.CategoriesForSelect = new SelectList
                (_dbContext.Categories.AsNoTracking()
                    .Where(a => a.ParentId == null)
                    .ToList(), "Id", "Name");

            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(AddCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_dbContext.Categories.Any(category => category.Name == viewModel.Name))
                {
                    ModelState.AddModelError("Name", "این نام قبلا ثبت شده است");
                    return View(viewModel);
                }
                _dbContext.Categories.Add(new Category
                {
                    Description = viewModel.Description,
                    ParentId = viewModel.ParentId == 0 ? null : viewModel.ParentId,
                    KeyWords = viewModel.KeyWords,
                    Name = viewModel.Name,
                    DisplayOrder = viewModel.DisplayOrder
                });
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Create", "Category");
            }
            ViewBag.CategoriesForSelect = new SelectList
                (_dbContext.Categories.AsNoTracking()
                    .Where(a => a.ParentId == null)
                    .ToList(), "Id", "Name", viewModel.ParentId);
            return View(viewModel);
        }

        #endregion

        #region Index , List

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult List(string term = "", int page = 1)
        {
            int total;
            var categories = GetDataTable(out total, term, page, 10);
            ViewBag.TotalCategories = total;
            ViewBag.PageNumber = page;
            return PartialView("_ListPartial", categories);
        }

        #endregion

        #region Edit

        [HttpGet]
        [Route("Edit/{id}")]
        public virtual ActionResult Edit(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category = _dbContext.Categories.Where(a => a.Id == id).Select(a =>
                new EditCategoryViewModel
                {
                    Id = a.Id,
                    Description = a.Description,
                    Name = a.Name,
                    DisplayOrder = a.DisplayOrder,
                    KeyWords = a.KeyWords
                }).FirstOrDefault();
            if (category == null) return HttpNotFound();
            return View(category);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(EditCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            if (!_dbContext.Categories.Any(category => category.Id != viewModel.Id
                                                       && category.Name == viewModel.Name))
            {
                ModelState.AddModelError("Name", "این نام قبلا ثبت شده است");
                return View(viewModel);
            }
            var selectedCategory = _dbContext.Categories.First(a => a.Id == viewModel.Id);
            selectedCategory.Description = viewModel.Description;
            selectedCategory.KeyWords = viewModel.KeyWords;
            selectedCategory.Name = viewModel.Name;
            selectedCategory.DisplayOrder = viewModel.DisplayOrder;
            selectedCategory.Id = viewModel.Id;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Category");
        }

        #endregion

        #region Delete

        [Route("Delete/{id}")]
        public virtual async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
                return
                    new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category = _dbContext.Categories.First(a => a.Id == id);
            if (category == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Category");
        }

        #endregion

        #endregion

        #region Validation

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult CheckExistCategoryforAdd(string name)
        {
            return CheckExistName(name) ? Json(false) : Json(true);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult CheckExistCategoryforEdit(string name, long id)
        {
            return CheckExistName(name, id) ? Json(false) : Json(true);
        }

        #endregion

        #region  Methods
        [NonAction]
        public bool CheckExistName(string name)
        {
            return _dbContext.Categories.Any(category => category.Name == name);
        }
        [NonAction]
        public bool CheckExistName(string name, long id)
        {
            return _dbContext.Categories.Any(category => category.Id != id
                                                         && category.Name == name);
        }

        #endregion
    }
}