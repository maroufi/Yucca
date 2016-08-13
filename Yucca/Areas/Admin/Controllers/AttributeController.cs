using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EntityFramework.Extensions;
using Yucca.Areas.Admin.ViewModels.Attribute;
using Yucca.Data.DbContext;
using Yucca.Models.Products;

namespace Yucca.Areas.Admin.Controllers
{
    public class AttributeController : Controller
    {
        private YuccaDbContext _dbContext;

        public AttributeController()
        {
            _dbContext=new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        #region Index
        // GET: Admin/Attribute
        [HttpGet]
        [Route("{categoryId}/Attributes")]
        public ActionResult Index(long? categoryId)
        {
            if (categoryId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category = _dbContext.Categories.First(a => a.Id == categoryId);
            if (category == null) return HttpNotFound();
            var attributes = _dbContext.SpecificAttributes.AsNoTracking()
                .Where(a => a.CategoryId == categoryId).ToList();
            List<AttributeViewModel> attributeViewModels= attributes.Select(attribute => new AttributeViewModel
            {
                CategoryId = attribute.CategoryId, Id = attribute.Id, Name = attribute.Name
            }).ToList();
            return View(attributeViewModels);
        }
        #endregion

        #region Edit
        [Route("Attribute/Edit/{id}")]
        [HttpGet]
        public virtual ActionResult Edit(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var attribute = _dbContext.SpecificAttributes.First(a => a.Id == id);
            if (attribute == null) return HttpNotFound();

            return View(new EditAttributeViewModel { Name = attribute.Name, CategoryId = attribute.CategoryId, Id = attribute.Id });
        }
        [Route("Attribute/Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(EditAttributeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var attribute = _dbContext.SpecificAttributes.First(a => a.Id == viewModel.Id);
            var oldName = attribute.Name;
            attribute.Name = viewModel.Name;
            //var status = _attributeService.Edit(attribute);
            if (!ExistByName(attribute.Name, attribute.Id, attribute.CategoryId))
            {
                ModelState.AddModelError("Name", "این ویژگی قبلا برای این گروه ثبت شده است");
                return View(viewModel);
            }
            var selectedAttribute = _dbContext.SpecificAttributes
                .First(a => a.Id == viewModel.Id);
            selectedAttribute.Name = viewModel.Name;
            selectedAttribute.CategoryId = viewModel.CategoryId;
            if (viewModel.CascadeAddForChildren)
            {
                var category = _dbContext.Categories.First(a => a.Id == viewModel.CategoryId);
                EditAttributeForChildrenCascade(oldName, viewModel.Name, category);
            }
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Category",
                new { categoryId = viewModel.CategoryId });
        }
        [NonAction]
        private void EditAttributeForChildrenCascade(string oldName, string newName, Category category)
        {
            if (category == null) return;
            if (!category.ChildCategories.Any()) return;
            var children = _dbContext.Categories.AsNoTracking().Where(a => a.Id == category.Id);
            foreach (var child in children.Where(child => HasAttributeByName(oldName, child.Id)))
            {
                EditByCategoryId(oldName, newName, child.Id);
            }
        }
        #endregion

        #region Add
        [Route("{categoryId}/Attribute/Add")]
        [HttpGet]
        public virtual ActionResult Add(long? categoryId)
        {
            if (categoryId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category = _dbContext.Categories.First(a => a.Id == categoryId);
            if (category == null) return HttpNotFound();
            var categories = _dbContext.Categories.ToList();
            ViewBag.CategoriesForSelect = new SelectList(categories, "Id", "Name", category.Id);
            ViewBag.CategoryName = category.Name;
            return View(new AddAttributeViewModel { CategoryId = category.Id });
        }

        [Route("{categoryId}/Attribute/Add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Add(AddAttributeViewModel viewModel)
        {
            var categoryId = viewModel.CategoryId;
            if (ModelState.IsValid)
            {
                if (ExistByName(viewModel.Name, viewModel.CategoryId))
                {
                    ModelState.AddModelError("Name", "این ویژگی قبلا برای این گروه ثبت شده است");
                    return View(viewModel);
                }
                var attribute = new SpecificAttribute()
                {
                    Name = viewModel.Name,
                    CategoryId = viewModel.CategoryId
                };
                _dbContext.SpecificAttributes.Add(attribute);
                if (viewModel.CascadeAddForChildren)
                {
                    var category =
                        _dbContext.Categories.Include("SpecificAttribute").FirstOrDefault(a => a.Id == viewModel.CategoryId);
                    AddAttributeToChildrenCascade(viewModel, category);
                }
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Add", "Attribute",
                    new { categoryId = categoryId });
            }
            var categories = _dbContext.Categories;
            ViewBag.CategoriesForSelect = new SelectList(categories, "Id", "Name", categoryId);
            return View(viewModel);

        }


        [NonAction]
        private void AddAttributeToChildrenCascade(AddAttributeViewModel viewModel, Category category)
        {
            if (category == null) return;
            if (!category.ChildCategories.Any()) return;
            var childern = _dbContext.Categories.AsNoTracking().Where(a => a.Id == category.Id).ToList();
            var attribute = new SpecificAttribute
            {
                Name = viewModel.Name,
                CategoryId = viewModel.CategoryId
            };
            foreach (var child in childern.Where(child => !HasAttributeByName(viewModel.Name, child.Id)))
            {
                viewModel.CategoryId = child.Id;
                _dbContext.SpecificAttributes.Add(attribute);
            }

        }
        #endregion

        #region Delete
        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var attribute = _dbContext.SpecificAttributes.Find(id);
            if (attribute == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category = _dbContext.Categories.Include("SpecificAttribute").FirstOrDefault(a => a.Id == id);
            _dbContext.MarkAsDeleted(attribute);
            DeleteAttributeFromChildrenOfCategory(category, attribute.Name);
            return RedirectToAction("Index", "Category");
        }


        [NonAction]
        private void DeleteAttributeFromChildrenOfCategory(Category category, string attributeName)
        {
            if (category == null) return;
            if (!category.ChildCategories.Any()) return;
            var children = _dbContext.Categories.AsNoTracking().Where(a => a.Id == category.Id).ToList();
            foreach (var child in children)
            {
                _dbContext.SpecificAttributes
                    .Where(a => a.CategoryId == child.Id && a.Name == attributeName).Delete();
            }
        }
        #endregion
        #region Validation
        [HttpPost]
        public virtual ActionResult AddCheckExistAttributeForCategory(string name, long categoryId)
        {
            return ExistByName(name, categoryId) ? Json(false) : Json(true);
        }
        [HttpPost]
        public virtual ActionResult EditCheckExistAttributeForCategory(string name, long id, long categoryId)
        {
            return ExistByName(name, id, categoryId) ? Json(false) : Json(true);
        }
        #endregion
        #region Method
        #region Methods
        public bool ExistByName(string name, long categoryId)
        {
            return _dbContext.SpecificAttributes.Any(a => a.CategoryId == categoryId && a.Name.Equals(name));
        }
        public bool ExistByName(string name, long id, long categoryId)
        {
            return _dbContext.SpecificAttributes.Any(a => a.CategoryId == categoryId && a.Id != id && a.Name.Equals(name));
        }
        public bool HasAttributeByName(string attributeName, long id)
        {
            return
                _dbContext.Categories
                    .Any(a => a.Id == id && a.Attributes.Any(b => b.Name == attributeName));
        }
        public void EditByCategoryId(string oldName, string newName, long categoryId)
        {
            var attribute = _dbContext.SpecificAttributes.Where(a => a.CategoryId == categoryId && a.Name.Equals(oldName));
            attribute.Update(a => new SpecificAttribute { Name = newName });
        }
        #endregion
        #endregion
    }
}