using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using Yucca.Areas.Admin.ViewModels.User;
using Yucca.Data.DbContext;
using Yucca.Filter;
using Yucca.Models.IdentityModels;
using Yucca.Models.Orders;
using Yucca.Utility.Security;

namespace Yucca.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Customers")]
    [Route("{action}")]
    //[SiteAuthorize(Roles = "admin")]
    public class UserController : Controller
    {
        private YuccaDbContext _dbContext;

        public UserController()
        {
            _dbContext=new YuccaDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }

        #region Index,List
        [HttpGet]
        public virtual ActionResult Index()
        {
            List<UserViewModel> usersListViewModel=new List<UserViewModel>();
            var users = _dbContext.Users.ToList();
            foreach (var user in users)
            {
                usersListViewModel.Add(new UserViewModel
                {
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    Baned = user.IsBanned,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleDescritpion = _dbContext.Roles.First(a=>a.Id== user.Roles.First().RoleId).Name
                });
            }
            return View(usersListViewModel);
        }
        #endregion

        #region Details
        [HttpGet]
        [Route("Details/{id:long}")]
        public virtual ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = _dbContext.Users.First(a => a.Id == id);
            if (user == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var userViewModel = new DetailsUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                RoleName = user.Roles.ToString(),
                PhoneNumber = user.PhoneNumber,
                LastLoginDate = user.LastLoginDate,
                IsBanned = user.IsBanned,
                BirthDay = user.BirthDay,
                BannedDate = user.BannedDate,
                AvatarPath = user.AvatarPath,
                Ip = user.Ip,
                PasswordHash = user.PasswordHash,
                AccessFailedCount = user.AccessFailedCount,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled
            };
            return View(userViewModel);
        }

        #endregion

        #region Edit User
        [Route("Edit/{id}")]
        [HttpGet]
        public virtual ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = _dbContext.Users.Include("Roles").Where(a => a.Id == id)
                .Select(a => new EditUserViewModel
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    PhoneNumber = a.PhoneNumber,
                    UserName = a.UserName,
                    Id = a.Id,
                    RoleId = a.Roles.First().RoleId,
                    IsBaned = a.IsBanned
                }).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.Roles = new SelectList(_dbContext.Roles.ToList(), "Id", "Description", user.RoleId);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public virtual async Task<ActionResult> Edit(EditUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (ExistsByPhoneNumberAndUserId(viewModel.PhoneNumber, viewModel.Id))
            {
                ModelState.AddModelError("PhoneNumber", "این شماره همراه قبلا ثبت شده است");
                return View(viewModel);
            }
            if (ExistsByUserNameAndUserId(viewModel.UserName, viewModel.Id))
            {
                ModelState.AddModelError("UserName", "این نام کاربری  قبلا ثبت شده است");
                return View(viewModel);
            }
            var user = _dbContext.Users.First(a => a.Id == viewModel.Id);
            user.LastName = viewModel.LastName;
            user.FirstName = viewModel.FirstName;
            user.Id = viewModel.Id;
            user.PasswordHash =
                viewModel.Password != null
                    ? Encryption.EncryptingPassword(viewModel.Password)
                    : null;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.IsBanned = viewModel.IsBaned;
            user.UserName = viewModel.UserName;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete User

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Delete(long? id)
        {
            var user = _dbContext.Users.First(a => a.Id == id);
            if (id == null || user == null) return Content(null);
            _dbContext.MarkAsDeleted(user);
            await _dbContext.SaveChangesAsync();
            return Content("ok");
        }
        #endregion

        #region Add User
        [HttpGet]
        [Route("Add")]
        public virtual ActionResult Create()
        {
            var roles = _dbContext.Roles.Select(x =>
              new SelectListItem { Text = x.Name, Value = x.Id.ToString(CultureInfo.InvariantCulture) });
            ViewBag.Roles = roles;
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("Add")]
        public virtual async Task<ActionResult> Create(AddUserViewModel viewModel)
        {
            var roles = _dbContext.Roles.Select(x =>
              new SelectListItem { Text = x.Name, Value = x.Id.ToString(CultureInfo.InvariantCulture) });
            ViewBag.Roles = roles;

            if (!ModelState.IsValid)
                return View(viewModel);
            if (ExistsByPhoneNumber(viewModel.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "این شماره همراه قبلا ثبت شده است");
                return View(viewModel);
            }
            if (ExistsByUserName(viewModel.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری مورد نظر قبلا ثبت شده است");
                return View(viewModel);
            }
            var role = _dbContext.Roles.FirstOrDefault(a => a.Id == viewModel.RoleId);
            if (role == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = new YuccaUser
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                LastLoginDate = DateTime.Now,
                UserName = viewModel.UserName,
                PasswordHash = Encryption.EncryptingPassword(viewModel.Password),
                PhoneNumber = viewModel.PhoneNumber
            };
            
            //var userRole = new YuccaUserRole { RoleId = role.Id, UserId = user.Id };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Create");
        }
        #endregion

        #region RemoteValidation
        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult AdminCheckUserNameIsExistForAdd(string userName)
        {
            return _dbContext.Users.Any(a=>a.UserName==userName)
                ? Json(false)
                : Json(true);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult AdminCheckPhoneNumberIsExistForAdd(string phoneNumber)
        {
            return _dbContext.Users.Any(a=>a.PhoneNumber== phoneNumber)
                ? Json(false)
                : Json(true);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult EditCheckUserNameIsExist(string userName, long id)
        {
            return _dbContext.Users.Any(a=>a.UserName==userName&&a.Id==id)
                ? Json(false)
                : Json(true);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult EditCheckPhoneNumberIsExist(string phoneNumber, long id)
        {
            return _dbContext.Users.Any(a=>a.PhoneNumber== phoneNumber&&a.Id==id)
                ? Json(false)
                : Json(true);
        }
        #endregion
        private bool ExistsByUserNameAndUserId(string userName, long id)
        {
            return _dbContext.Users.Any(a => a.UserName == userName && a.Id == id);
        }

        private bool ExistsByPhoneNumberAndUserId(string phoneNumber, long id)
        {
            return _dbContext.Users.Any(a => a.PhoneNumber == phoneNumber && a.Id == id);
        }

        private bool ExistsByPhoneNumber(string phoneNumber)
        {
            return _dbContext.Users.Any(a => a.PhoneNumber == phoneNumber);
        }
        private bool ExistsByUserName(string userName)
        {
            return _dbContext.Users.Any(a => a.UserName == userName);
        }
    }
}