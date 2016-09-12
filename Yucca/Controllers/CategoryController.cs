using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            ViewBag.Categories = _dbContext.Categories.Include(a=>a.Products).Include(a=>a.Slides).FirstOrDefault(a => a.Id == categoryId);
            if (ViewBag.Categories == null) return HttpNotFound();
            ViewBag.Pictures = _dbContext.ProductPictures.ToList();
            return View();
        }
    }
}