using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Yucca.Areas.Admin.ViewModels.ProductAttribute;
using Yucca.Data.DbContext;
using Yucca.Filter;

namespace Yucca.Areas.Admin.Controllers
{
    public class AttributeOptionController : Controller
    {
        private readonly YuccaDbContext _dbContext;

        public AttributeOptionController()
        {
            _dbContext=new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        // GET: Admin/AttributeOption
        #region FillAttributesOfCategory
        [HttpGet]
        [AjaxOnly]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0, VaryByParam = "*")]
        public virtual ActionResult FillAttributes(long? productId)
        {
            if (productId == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var values = _dbContext.AttributeOptions.Include("Product").Include("Attribute").Where(a => a.ProductId == productId).Select(a => new FillProductAttributesViewModel
            {
                Name = a.Attribute.Name,
                Id = a.Id,
                Value = a.Name
            }).ToList();
            return PartialView("FillAttributes", values);
        }

        [HttpPost]
        [AjaxOnly]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0, VaryByParam = "*")]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> FillAttributes(IEnumerable<FillProductAttributesViewModel> values)
        {
            if (values != null)
            {
                var fillProductAttributesViewModels = values as IList<FillProductAttributesViewModel> ?? values.ToList();
                var ids = fillProductAttributesViewModels.Select(a => a.Id);
                var selectedValues = _dbContext.AttributeOptions.Where(a => ids.Contains(a.Id)).ToList();
                for (var i = 0; i < selectedValues.Count; i++)
                {
                    selectedValues.ElementAt(i).Name = fillProductAttributesViewModels.ElementAt(i).Value;
                }
            }
            await _dbContext.SaveChangesAsync();
            return Content("ok");
        }
        #endregion
    }
}