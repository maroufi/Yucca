using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yucca.Data.DbContext;
using Yucca.ViewModels.Category;

namespace Yucca.Controllers
{
    public class CategoryController : Controller
    {
        private readonly YuccaDbContext _dbContext;

        public CategoryController()
        {
            _dbContext=new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index(long? categoryId)
        {
            if (categoryId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category = _dbContext.Categories.Include("Slides").FirstOrDefault(a => a.Id == categoryId);
            if (category == null) return HttpNotFound();
            var productsAndSlides = new ProductsOfCategoryViewModel();
            foreach (var product in category.Products)
            {
                productsAndSlides.Products.Add(new ProductViewModel
                {
                    Id = product.Id,
                    ImagePath = product.Pictures.First(a=>a.IsMainPicture==true).ImagePath,
                    Name = product.Name,
                    Price = product.Price
                });
            }
            foreach (var slide in category.Slides)
            {
                productsAndSlides.SlideShows.Add(new SlideShowViewModel
                {
                    Id = slide.Id,
                    Description = slide.Description,
                    ImagePath = slide.ImagePath,
                    Title = slide.Title,
                    ImageAltText = slide.ImageAltText,
                    Position = slide.Position,
                    HideTransition = slide.HideTransition,
                    ShowTransition = slide.ShowTransition,
                    Link = slide.Link
                });
            }
            return View(productsAndSlides);
        }
    }
}