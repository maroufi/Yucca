using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace Yucca.Areas.Admin.ViewModels.Product
{
    public class EditProductViewModel
    {
        public long Id { get; set; }
        public long OldCategoryId { get; set; }
        [DisplayName("نام کالا")]
        [Required(ErrorMessage = "لطفا نام کالا را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد حروف نام کالا غیر مجاز است")]
        
        public string Name { get; set; }
        [DisplayName("توضیحات سئو")]
        [Required(ErrorMessage = "لطفا توضیحات سئو را وارد کنید")]
        [MaxLength(400, ErrorMessage = "تعداد حروف توضیحات سئو غیر مجاز است")]
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }
        [DisplayName("توضیحات ")]
        [Required(ErrorMessage = "لطفا  توضیحات  را وارد کنید")]
        [DataType(DataType.MultilineText)]
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
        [RegularExpression(@"^\$?\d+(\.(\d{1}))?$", ErrorMessage = "لطفا مقدار(تعداد) هشدار  را درست وارد کنید ")]
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public int Stock { get; set; }
        [DisplayName("مقدار(تعداد) هشدار")]
        [Required(ErrorMessage = "لطفا مقدار(تعداد) هشدار  را مشخص کنید ")]
        [RegularExpression(@"^\$?\d+(\.(\d{1}))?$", ErrorMessage = "لطفا مقدار(تعداد) هشدار  را درست وارد کنید ")]
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public int NotificationStockMinimum { get; set; }
        [DisplayName("قیمت (تومان)")]
        [Required(ErrorMessage = "لطفا قیمت  را مشخص کنید ")]
        [Integer(ErrorMessage = "فقط از اعداد صحیح استفاده کنید")]
        public long Price { get; set; }
        [DisplayName("ضریبی برای خرید")]
        [Required(ErrorMessage = "لطفا ضریب خرید  را مشخص کنید ")]
        [RegularExpression(@"^\$?\d+(\.(\d{1}))?$", ErrorMessage = "لطفا ضریب  را درست وارد کنید")]
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public decimal Ratio { get; set; }
        [DisplayName("استفاده از تخفیف گروه")]
        public bool ApplyCategoryDiscount { get; set; }
        [DisplayName("گروه")]
        [Required(ErrorMessage = "لطفا گروه کالا را مشخص کنید ")]
        public long CategoryId { get; set; }
        [DisplayName("تخفیف")]
        [Required(ErrorMessage = "درصد تخفیف را مشخص کنید")]
        [Range(0, 100, ErrorMessage = "درصد تخفیف میبایست 0 تا 100 انتخاب شود")]
        [Integer(ErrorMessage = "فقط از اعداد صحیح استفاده کنید")]
        public int DiscountPercent { get; set; }
        [DisplayName("عدم نمایش")]
        public bool Deleted { get; set; }
    }
}
