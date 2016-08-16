using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using Yucca.Areas.Admin.ViewModels.Setting;
using Yucca.Data.DbContext;
using Yucca.Filter;

namespace Yucca.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Setting")]
    [Route("{action}")]
    [SiteAuthorize(Roles = "admin")]
    public partial class SettingController : Controller
    {
        private readonly YuccaDbContext _dbContext;

        public SettingController()
        {
            _dbContext=new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        #region Edit
        [Route("Edit")]
        [HttpGet]
        public virtual ActionResult Edit()
        {
            var settings = _dbContext.Settings.ToList();
            var model = new EditSettingViewModel
            {
                StoreName = settings.First(a => a.Name=="StoreName").Value,
                StoreKeyWords = settings.First(a => a.Name.Equals("StoreKeyWords")).Value,
                StoreDescription = settings.First(a => a.Name.Equals("StoreDescription")).Value,
                Tel1 = settings.First(a => a.Name.Equals("Tel1")).Value,
                Tel2 = settings.First(a => a.Name.Equals("Tel2")).Value,
                PhoneNumber1 = settings.First(a => a.Name.Equals("PhoneNumber1")).Value,
                PhoneNumber2 = settings.First(a => a.Name.Equals("PhoneNumber2")).Value,
                Address = settings.First(a => a.Name.Equals("Address")).Value
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]
        public virtual async Task<ActionResult> Edit(EditSettingViewModel viewModel)
        {
            var settings = _dbContext.Settings.ToList();
            settings.First(a => a.Name.Equals("StoreName")).Value = viewModel.StoreName;
            settings.First(a => a.Name.Equals("StoreKeyWords")).Value = viewModel.StoreKeyWords;
            settings.First(a => a.Name.Equals("StoreDescription")).Value = viewModel.StoreDescription;
            settings.First(a => a.Name.Equals("Tel1")).Value = viewModel.Tel1;
            settings.First(a => a.Name.Equals("Tel2")).Value = viewModel.Tel2;
            settings.First(a => a.Name.Equals("PhoneNumber1")).Value = viewModel.PhoneNumber1;
            settings.First(a => a.Name.Equals("PhoneNumber2")).Value = viewModel.PhoneNumber2;
            settings.First(a => a.Name.Equals("Address")).Value = viewModel.Address;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        #endregion
    }
}
