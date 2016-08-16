using System.ComponentModel;

namespace Yucca.Areas.Admin.ViewModels.User
{
    public class DetailsUserViewModel
    {
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
        [DisplayName("تعداد نظرات")]
        public int CommentsCount { get; set; }
        [DisplayName("تعداد خرید ")]
        public int OrdersCount { get; set; }
        [DisplayName("آدرس آی پی")]
        public string IP { get; set; }
        [DisplayName("وضعیت عضویت")]
        public string RegisterType { get; set; }
    }
}
