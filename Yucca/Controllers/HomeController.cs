using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yucca.Data.DbContext;
using Yucca.Models.Products;
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
            ViewBag.Categories = _dbContext.Categories.Include(a => a.Products).ToList();
            ViewBag.Pictures = _dbContext.ProductPictures.ToList();
            return View();
        }

        public ActionResult Menu()
        {
            ViewBag.CategoriesForMenu = _dbContext.Categories.ToList();
            return PartialView("_MenuPartial");
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