using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using EntityFramework.Extensions;
using Yucca.Areas.Admin.ViewModels.SlideShow;
using Yucca.Data.DbContext;
using Yucca.Filter;
using Yucca.Helpers;
using Yucca.Models.Products;

namespace Yucca.Areas.Admin.Controllers
{
    [SiteAuthorize(Roles = "admin")]
    [RouteArea("Admin")]
    [RoutePrefix("CategorySlides")]
    [Route("{action}")]
    public class CategorySlidesController : Controller
    {
        private YuccaDbContext _dbContext;

        public CategorySlidesController()
        {
            _dbContext=new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        #region SlideShow
        [Route("Index")]
        public virtual ActionResult Index(long? categoryId)
        {
            var slides = _dbContext.CategorySlides.ToList();
            return View(slides);
        }
        [HttpGet]
        [Route("Add")]
        public virtual ActionResult Create()
        {
            PopulateCategoriesDropDownList(null, null, null);
            return View();

        }
        [HttpPost]
        [Route("Add")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(AddSlideShowViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var slide = new CategorySlide
                {
                    Link = viewModel.Link,
                    ImageAltText = viewModel.ImageAltText,
                    ImagePath = viewModel.ImagePath,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    DataHorizontal = viewModel.DataHorizontal,
                    HideTransition = viewModel.HideTransition,
                    Position = viewModel.Position,
                    ShowTransition = viewModel.ShowTransition,
                    DataVertical = viewModel.DataVertical

                };
                _dbContext.CategorySlides.Add(slide);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Create", "CategorySlides");
            }
            PopulateCategoriesDropDownList(viewModel.ShowTransition, viewModel.HideTransition, viewModel.Position);
            return View(viewModel);

        }

        [HttpGet]
        [Route("Edit/{id}")]
        public virtual ActionResult Edit(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var slide = _dbContext.CategorySlides.Where(a => a.Id == id).Select(a => new EditSlideShowViewModel
            {
                Id = a.Id,
                ImageAltText = a.ImageAltText,
                ImagePath = a.ImagePath,
                Title = a.Title,
                Link = a.Link,
                Description = a.Description,
                DataHorizontal = a.DataHorizontal,
                HideTransition = a.HideTransition,
                Position = a.Position,
                ShowTransition = a.ShowTransition,
                DataVertical = a.DataVertical

            }).FirstOrDefault();
            if (slide == null)
                return HttpNotFound();
            PopulateCategoriesDropDownList(slide.ShowTransition, slide.HideTransition, slide.Position);
            return View(slide);
        }
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(EditSlideShowViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var slide = new CategorySlide
                {
                    Id = viewModel.Id,
                    ImageAltText = viewModel.ImageAltText,
                    Link = viewModel.Link,
                    ImagePath = viewModel.ImagePath,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    DataHorizontal = viewModel.DataHorizontal,
                    HideTransition = viewModel.HideTransition,
                    Position = viewModel.Position,
                    ShowTransition = viewModel.ShowTransition,
                    DataVertical = viewModel.DataVertical

                };
                _dbContext.MarkAsChanged(slide);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "CategorySlides");
            }
            PopulateCategoriesDropDownList(viewModel.ShowTransition, viewModel.HideTransition, viewModel.Position);
            return View(viewModel);
        }

        [AjaxOnly]
        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        [Route("Delete/{id}")]
        public virtual async Task<ActionResult> Delete(long? id)
        {
            if (id == null) return 
                    new HttpStatusCodeResult(HttpStatusCode.BadRequest); ;
            var slide = _dbContext.CategorySlides.First(a => a.Id == id);
            if (slide == null) return 
                    new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            _dbContext.MarkAsDeleted(slide);
            await _dbContext.SaveChangesAsync();
            return Content("ok");
        }


        void PopulateCategoriesDropDownList(string showTranstion, string hideTranstion, string position)
        {
            ViewBag.ShowTransitionList = DropDown.GetShowTranstionSlide(showTranstion);
            ViewBag.HideTransitionList = DropDown.GetHideTranstionSlide(hideTranstion);
            ViewBag.PositionList = DropDown.GetPositonSlide(position);
        }
        #endregion
    }
}