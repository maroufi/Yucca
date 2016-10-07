using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace Yucca.Areas.Admin.ViewModels.Product
{
    public class AddProductViewModel
    {
        [DisplayName("نام کالا")]
        [Required(ErrorMessage = "لطفا نام کالا را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد حروف نام کالا غیر مجاز است")]
        public string Name { get; set; }
        [DisplayName("توضیحات سئو")]
        [Required(ErrorMessage = "لطفا توضیحات سئو را وارد کنید")]
        [MaxLength(400, ErrorMessage = "تعداد حروف توضیحات سئو غیر مجاز است")]
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("توضیحات ")]
        [Required(ErrorMessage = "لطفا  توضیحات  را وارد کنید")]
        public string Description { get; set; }
        [DisplayName("کلمات کلیدی")]
        [Required(ErrorMessage = "لطفا کلمات کلیدی را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد حروف کلمات کلیدی غیر مجاز است")]
        [DataType(DataType.MultilineText)]
        public string MetaKeyWords { get; set; }
        [DisplayName("آدرس تصویر اصلی")]
        [Required(ErrorMessage = "لطفا آدرس تصویر را وارد کنید")]
        public string PrincipleImagePath { get; set; }
        [DisplayName("ارسال رایگان")]
        public bool IsFreeShipping { get; set; }
        [DisplayName("مقدار(تعداد)  موجود")]
        [Required(ErrorMessage = "لطفا مقدار(تعداد) موجود را مشخص  کنید")]
        [RegularExpression(@"^\$?\d+(\.(\d{1}))?$", ErrorMessage = "لطفا مقدار(تعداد) موجود را درست وارد  کنید")]
        public int Stock { get; set; }
        [DisplayName("مقدار(تعداد) هشدار")]
        [Required(ErrorMessage = "لطفا مقدار(تعداد) هشدار  را مشخص کنید ")]
        [RegularExpression(@"^\$?\d+(\.(\d{1}))?$", ErrorMessage = "لطفا مقدار(تعداد) هشدار  را درست وارد کنید ")]
        public int NotificationStockMinimum { get; set; }
        [DisplayName("قیمت (تومان)")]
        [Required(ErrorMessage = "لطفا قیمت  را مشخص کنید ")]
        [Integer(ErrorMessage = "فقط از اعداد صحیح استفاده کنید")]
        public int Price { get; set; }
        [DisplayName("گروه")]
        [Required(ErrorMessage = "لطفا گروه کالا را مشخص کنید ")]
        public long CategoryId { get; set; }
        [DisplayName("عدم نمایش")]
        public bool Deleted { get; set; }
    }
}
