using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace Yucca.Areas.Admin.ViewModels.Setting
{
    public class EditSettingViewModel
    {
        [DisplayName("نام فروشگاه")]
        public string StoreName { get; set; }
        [DisplayName("کلمات کلیدی")]
        [DataType(DataType.MultilineText)]
        public string StoreKeyWords { get; set; }
        [DisplayName("توضیحات سئو")]
        [DataType(DataType.MultilineText)]
        public string StoreDescription { get; set; }
        [DisplayName("شماره تماس 1")]
        public string Tel1 { get; set; }
        [DisplayName("شماره تماس 2")]
        public string Tel2 { get; set; }
        [DisplayName("آدرس فروشگاه")]
        public string Address { get; set; }
        [DisplayName("شماره موبایل 1")]
        public string PhoneNumber1 { get; set; }
        [DisplayName("شماره موبایل 2")]
        public string PhoneNumber2 { get; set; }
        [DisplayName("ایمیل فروشگاه")]
        [Email]
        public string ShopEmail { get; set; }
        [DisplayName("توضیحات صفحه درباره فروشگاه")]
        [DataType(DataType.MultilineText)]
        public string AboutPageDescription { get; set; }
        [DisplayName("توضیحات صفحه ارتباط  ")]
        [DataType(DataType.MultilineText)]
        public string ContactPageDescription { get; set; }
    }
}
