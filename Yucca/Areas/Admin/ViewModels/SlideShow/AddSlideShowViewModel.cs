using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace Yucca.Areas.Admin.ViewModels.SlideShow
{
    public class AddSlideShowViewModel
    {
        [DisplayName("عنوان")]
        [MaxLength(30, ErrorMessage = "تعداد حروف عنوان غیر مجاز است")]
        [Required(ErrorMessage = "عنوان نباید خالی باشد")]
        public string Title { get; set; }

        [DisplayName("آدرس تصویر")]
        [Required(ErrorMessage = "آدرس تصویر نباید خالی باشد")]
        public string ImagePath { get; set; }

        [DisplayName("متن جایگزین")]
        [Required(ErrorMessage = "متن جایگزین نباید خالی باشد")]
        [MaxLength(30, ErrorMessage = "تعداد حروف متن جایگزین غیر مجاز است")]
        public string ImageAltText { get; set; }

        [DisplayName("لینک")]
        [Required(ErrorMessage = "لینک نباید خالی باشد")]
        public string Link { get; set; }
        [DisplayName("توضیحات")]
        [MaxLength(300, ErrorMessage = "تعداد حروف توضیحات غیر مجاز است")]
        [Required(ErrorMessage = "توضیحات نباید خالی باشد")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("مکان توضیحات")]
        [Required(ErrorMessage = "مکان توضیخات را انتخاب کنید")]
        public virtual string Position { get; set; }
        [DisplayName("جهت ظاهر شدن")]
        [Required(ErrorMessage = "جهت ظاهر شدن را انتخاب کنید")]
        public virtual string ShowTransition { get; set; }
        [DisplayName("جهت محو شدن")]
        [Required(ErrorMessage = " جهت محو شدن را انتخاب کنید")]
        public virtual string HideTransition { get; set; }
        [DisplayName("فاصله عمودی")]
        [Required(ErrorMessage = "فاصله عمودی کادر توضیحات را وارد کنید")]
        [Range(0, 100, ErrorMessage = "درصد تخفیف میبایست 0 تا 100 انتخاب شود")]
        [Integer(ErrorMessage = "فقط از اداد صحیح استفاده کنید")]
        public virtual int DataVertical { get; set; }
        [DisplayName("فاصله افقی")]
        [Required(ErrorMessage = "فاصله افقی توضیحات را وارد کنید")]
        [Range(0, 100, ErrorMessage = "درصد تخفیف میبایست 0 تا 100 انتخاب شود")]
        [Integer(ErrorMessage = "فقط از اعداد صحیح استفاده کنید")]
        public virtual int DataHorizontal { get; set; }

    }
}
