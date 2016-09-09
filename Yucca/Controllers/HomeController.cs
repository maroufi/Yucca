using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yucca.Data.DbContext;
using Yucca.ViewModels.Home;

namespace Yucca.Controllers
{
    public class HomeController : Controller
    {
        private readonly YuccaDbContext _dbContext;

        public HomeController()
        {
            _dbContext=new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            var mainPageViewModel=new MainPageViewModel();
            var categories = _dbContext.Categories.Where(a => a.IsDeleted == false).ToList();
            foreach (var category in categories)
            {
                mainPageViewModel.Categories.Add(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    ParentId = category.ParentId,
                    IsDeleted = category.IsDeleted,
                    KeyWords = category.KeyWords,
                    DisplayOrder = category.DisplayOrder
                });
            }
            var products = _dbContext.Products.ToList();
            foreach (var product in products)
            {
                mainPageViewModel.Products.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Price = product.Price
                });
            }
            var productPictures = _dbContext.ProductPictures.ToList();
            foreach (var picture in productPictures)
            {
                mainPageViewModel.ProductPictures.Add(new ProductPictureViewModel
                {
                    Id = picture.Id,
                    ProductId = picture.ProductId,
                    Description = picture.Description,
                    ImagePath = picture.ImagePath,
                    Title = picture.Title,
                    ImageAltText = picture.ImageAltText,
                    IsMainPicture = picture.IsMainPicture
                });
            }
            return View(mainPageViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}