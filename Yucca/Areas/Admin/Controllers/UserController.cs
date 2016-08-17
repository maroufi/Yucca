/*using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using Yucca.Areas.Admin.ViewModels.User;
using Yucca.Filter;
using Yucca.Models.Orders;
using Yucca.Utility.Security;

namespace Yucca.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [RoutePrefix("Customers")]
    [Route("{action}")]
    [SiteAuthorize(Roles = "admin")]
    public class UserController : Controller
    {

        #region Index,List
        [HttpGet]
        public virtual ActionResult Index()
        {
            ViewBag.UserSearchByList = DropDown.GetUserSearchByList(UserSearchBy.PhoneNumber);
            return View();
        }
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public virtual ActionResult List(string term = "", int pageNumber = 1, int pageCount = 10,
            Order order = Order.Descending, UserOrderBy userOrderBy
            = UserOrderBy.RegisterDate, UserSearchBy userSearchBy = UserSearchBy.PhoneNumber)
        {
            #region Retrive Data
            int totalUsers;
            var users = _userService.GetDataTable(out totalUsers, term, pageNumber, pageCount, order, userOrderBy, userSearchBy);
            var model = new UsersListViewModel
            {
                UserOrderBy = userOrderBy,
                Term = term,
                PageNumber = pageNumber,
                Order = order,
                UsersList = users,
                TotalUsers = totalUsers,
                PageCount = pageCount
            };
            #endregion
            ViewBag.UserSearchByList = DropDown.GetUserSearchByList(userSearchBy);
            ViewBag.UserOrderByList = DropDown.GetUserOrderByList(userOrderBy);
            ViewBag.CountList = DropDown.GetCountList(pageCount);
            ViewBag.OrderList = DropDown.GetOrderList(order);
            ViewBag.UserSearchBy = userSearchBy;
            return PartialView(MVC.Admin.User.Views._ListPartial, model);
        }


        #endregion

        #region Details
        [HttpGet]
        [Route("Details/{id:long}")]
        public virtual ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = _userService.GetUserDetail(id.Value);
            if (user == null)
                return HttpNotFound();
            return System.Web.UI.WebControls.View(user);
        }

        #endregion

        #region Edit User
        [Route("Edit/{id}")]
        [HttpGet]
        public virtual ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = _userService.GetUserDataForEdit(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.Roles = new SelectList(_roleService.GetAllRoles(), "Id", "Description", user.RoleId);
            return System.Web.UI.WebControls.View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public virtual async Task<ActionResult> Edit(EditUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            var editedUser = new User
            {
                LastName = viewModel.LastName,
                FirstName = viewModel.FirstName,
                Id = viewModel.Id,
                Password =
                    viewModel.Password != null
                        ? Encryption.EncryptingPassword(viewModel.Password) : null,
                PhoneNumber = viewModel.PhoneNumber,
                Role = _roleService.GetRoleByRoleId(viewModel.RoleId),
                IsBaned = viewModel.IsBaned,
                UserName = viewModel.UserName
            };
            var status = _userService.EditUser(editedUser);
            if (status == EditedUserStatus.UpdatingUserSuccessfully)
            {
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(MVC.Admin.User.ActionNames.Index);
            }

            switch (status)
            {
                case EditedUserStatus.PhoneNumberExist:
                    ModelState.AddModelError("PhoneNumber", "این شماره همراه قبلا ثبت شده است");
                    break;
                case EditedUserStatus.UserNameExist:
                    ModelState.AddModelError("UserName", "این نام کاربری  قبلا ثبت شده است");
                    break;
            }

            return View(viewModel);
        }
        #endregion

        #region Delete User

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Delete(long? id)
        {
            if (id == null) return Content(null);
            await _commentService.RemoveUserComments(id.Value);
            _userService.Remove(id.Value);
            await _unitOfWork.SaveChangesAsync();
            return Content("ok");
        }
        #endregion

        #region Add User
        [HttpGet]
        [Route("Create")]
        public virtual ActionResult Add()
        {
            var roles = _roleService.GetAllRoles().Select(x =>
              new SelectListItem { Text = x.Description, Value = x.Id.ToString(CultureInfo.InvariantCulture) });
            ViewBag.Roles = roles;
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("Create")]
        public virtual async Task<ActionResult> Add(AddUserViewModel viewModel)
        {
            var roles = _roleService.GetAllRoles().Select(x =>
              new SelectListItem { Text = x.Description, Value = x.Id.ToString(CultureInfo.InvariantCulture) });
            ViewBag.Roles = roles;

            if (!ModelState.IsValid)
                return View(viewModel);
            var user = new User
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                RegisterDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
                UserName = viewModel.UserName,
                Password = Encryption.EncryptingPassword(viewModel.Password),
                PhoneNumber = viewModel.PhoneNumber,
                Role = _roleService.GetRoleByRoleId(viewModel.RoleId)
            };

            var addUserStatus = _userService.Add(user);
            if (addUserStatus == AddUserStatus.AddingUserSuccessfully)
            {
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(MVC.Admin.User.ActionNames.Add);
            }
            switch (addUserStatus)
            {
                case AddUserStatus.PhoneNumberExist:
                    ModelState.AddModelError("PhoeNumber", "شماره همراه مورد نظر قبلا ثبت شده است");
                    break;
                case AddUserStatus.UserNameExist:
                    ModelState.AddModelError("UserName", "نام کاربری مورد نظر قبلا ثبت شده است");
                    break;
            }
            return View(viewModel);
        }

        #endregion

        #region RemoteValidation
        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult AdminCheckUserNameIsExistForAdd(string userName)
        {
            return _userService.ExistsByUserName(userName)
                ? Json(false)
                : Json(true);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult AdminCheckPhoneNumberIsExistForAdd(string phoneNumber)
        {
            return _userService.ExistsByPhoneNumber(phoneNumber)
                ? Json(false)
                : Json(true);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult EditCheckUserNameIsExist(string userName, long id)
        {
            return _userService.ExistsByUserName(userName, id)
                ? Json(false)
                : Json(true);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0)]
        public virtual JsonResult EditCheckPhoneNumberIsExist(string phoneNumber, long id)
        {
            return _userService.ExistsByPhoneNumber(phoneNumber, id)
                ? Json(false)
                : Json(true);
        }
        #endregion

    }
}*/