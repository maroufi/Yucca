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
            ViewBag.Message = "یوکا یکی از مشهورترین گیاهان آپارتمانی است، ساقه بلندی دارد که برگهای کشیده و سبزرنگش بر این ساقه استوارند. در نوعی یوکا که به یوکای خنجری معروف است برگها کشیده، بلند و نوک تیز و شبیه خنجرند. یوکاهایی که در خارج از آپارتمان نگهداری می شوند در بعضی از سالها گلهایی سفید و زنگوله ای می دهند.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}