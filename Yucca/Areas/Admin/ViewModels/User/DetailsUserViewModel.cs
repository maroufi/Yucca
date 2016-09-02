using System;
using System.ComponentModel;

namespace Yucca.Areas.Admin.ViewModels.User
{
    public class DetailsUserViewModel
    {
        public long Id { get; set; }
        [DisplayName("نام")]
        public string FirstName { get; set; }
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }
        [DisplayName("نقش کاربری")]
        public string RoleName { get; set; }
        [DisplayName("نام کاربری")]
        public string UserName { get; set; }
        [DisplayName("شماره تماس")]
        public string PhoneNumber { get; set; }
        [DisplayName("تصویر پروفابل")]
        public string AvatarPath { get; set; }
        [DisplayName("تاریخ تولد")]
        public DateTime? BirthDay { get; set; }
        [DisplayName("آدرس آی پی")]
        public string Ip { get; set; }
        [DisplayName("کاربر متوقف شده؟")]
        public bool IsBanned { get; set; }
        [DisplayName("زمان توقف کاربر")]
        public DateTime? BannedDate { get; set; }
        [DisplayName("زمان آخرین لاگین")]
        public DateTime? LastLoginDate { get; set; }
        [DisplayName("تعداد خطای دسترسی")]
        public int AccessFailedCount { get; set; }
        [DisplayName("ایمیل")]
        public string Email { get; set; }
        [DisplayName("ایمیل تایید شده؟")]
        public bool EmailConfirmed { get; set; }
        [DisplayName("کلمه عبور")]
        public string PasswordHash { get; set; }
        [DisplayName("تایید شماره تلفن")]
        public bool PhoneNumberConfirmed { get; set; }
        [DisplayName("فعال سازی 2فکتور")]
        public bool TwoFactorEnabled { get; set; }
    }
}
