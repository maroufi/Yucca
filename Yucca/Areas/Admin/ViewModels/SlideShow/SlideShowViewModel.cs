using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataAnnotationsExtensions;

namespace Yucca.Areas.Admin.ViewModels.SlideShow
{
    public class SlideShowViewModel
    {
        public long Id { get; set; }
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
        public string Position { get; set; }
        [DisplayName("جهت ظاهر شدن")]
        [Required(ErrorMessage = "جهت ظاهر شدن را انتخاب کنید")]
        public string ShowTransition { get; set; }
        [DisplayName("جهت محو شدن")]
        [Required(ErrorMessage = " جهت محو شدن را انتخاب کنید")]
        public string HideTransition { get; set; }
    }
}