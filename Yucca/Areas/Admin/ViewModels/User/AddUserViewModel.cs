using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Yucca.Areas.Admin.ViewModels.User
{
    public class AddUserViewModel
    {
        [DisplayName("نام نمایشی")]
        [Required(ErrorMessage = "لطفا نام نمایشی  را وارد کنید")]
        [MinLength(5, ErrorMessage = "نام نمایشی  باید بیشتر از 5 حرف باشد")]
        [MaxLength(30, ErrorMessage = "نام نمایشی نمیتواند بیشتر از 30 کاراکتر باشد")]
        [Remote("AdminCheckUserNameIsExistForAdd", "User", "Admin", ErrorMessage = "این نام کاربری قبلا توسط اعضا انتخاب شده است", HttpMethod = "POST")]
        public string UserName { get; set; }
        [DisplayName("شماره همراه")]
        [Required(ErrorMessage = "لطفا برای تکمیل ثبت نام شماره همراه  را وارد کنید")]
        [Remote("AdminCheckPhoneNumberIsExistForAdd", "User", "Admin", ErrorMessage = "این شماره همراه قبلا ثبت شده است", HttpMethod = "POST")]
        [RegularExpression("09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "لطفا شماره همراه  را به شکل صحیح وارد کنید")]
        public string PhoneNumber { get; set; }
        [DisplayName("کلمه عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور وارد کنید")]
        [MaxLength(128, ErrorMessage = "کلمه عبور باید کمتر از 128 حرف باشد")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 6 حرف باشد")]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "کلمه عبور و تکرارش باید یکسان باشند")]
        [DisplayName("تکرار کلمه عبور")]
        public string ConfirmPassword { get; set; }
        [MaxLength(30, ErrorMessage = "تعداد حروف مشخصه نام غیر مجاز است")]
        [DisplayName("نام")]
        public string FirstName { get; set; }
        [MaxLength(40, ErrorMessage = "تعداد حروف مشخصه نام خانوادگی غیر مجاز است")]
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }
        [DisplayName("نقش کاربری")]
        [Required(ErrorMessage = "نقش کاربر را مشخص کنید")]
        public long RoleId { get; set; }
    
    }
}
