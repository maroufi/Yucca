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
        [MaxLength(400, ErrorMessage = "تعداد حروف توضیحات سئو غیر مجاز است")]
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }
        [DisplayName("توضیحات ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = "تعداد حروف کلمات کلیدی غیر مجاز است")]
        [DataType(DataType.MultilineText)]
        public string MetaKeyWords { get; set; }
        [DisplayName("آدرس تصویر اصلی")]
        public string PrincipleImagePath { get; set; }
        [DisplayName("ارسال رایگان")]
        public bool IsFreeShipping { get; set; }
        [DisplayName("مقدار(تعداد)  موجود")]
        [Required(ErrorMessage = "لطفا مقدار(تعداد) موجود را مشخص  کنید")]
        [RegularExpression(@"^\$?\d+(\.(\d{1}))?$", ErrorMessage = "لطفا مقدار(تعداد) هشدار  را درست وارد کنید ")]
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public int Stock { get; set; }
        [DisplayName("مقدار(تعداد) هشدار")]
        [RegularExpression(@"^\$?\d+(\.(\d{1}))?$", ErrorMessage = "لطفا مقدار(تعداد) هشدار  را درست وارد کنید ")]
        [DisplayFormat(DataFormatString = "{0:0.#}", ApplyFormatInEditMode = true)]
        public int NotificationStockMinimum { get; set; }
        [DisplayName("قیمت (تومان)")]
        [Required(ErrorMessage = "لطفا قیمت کالا را مشخص  کنید")]
        [Integer(ErrorMessage = "فقط از اعداد صحیح استفاده کنید")]
        public long Price { get; set; }
        [DisplayName("گروه")]
        [Required(ErrorMessage = "لطفا گروه کالا را مشخص کنید ")]
        public long CategoryId { get; set; }
        [DisplayName("عدم نمایش")]
        public bool Deleted { get; set; }
    }
}
