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
            ViewBag.Categories = _dbContext.Categories.ToList();
            ViewBag.Products = _dbContext.Products.ToList();
            ViewBag.Pictures = _dbContext.ProductPictures.ToList();
            return View();
        }

        public ActionResult Menu()
        {
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