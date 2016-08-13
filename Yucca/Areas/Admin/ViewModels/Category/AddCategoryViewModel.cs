using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Yucca.Areas.Admin.ViewModels.Category
{
    public class AddCategoryViewModel
    {
        public int Level { get; set; }
        public long Id { get; set; }
        [Remote("CheckExistCategoryforAdd", "Category", "Admin", ErrorMessage = "این گروه قبلا ثبت شده است", HttpMethod = "POST")]
        [DisplayName("نام")]
        [Required(ErrorMessage = "وارد کردن نام گروه ضرویست")]
        [MaxLength(25, ErrorMessage = "تعداد حروف نام گروه غیر مجاز است")]
        public string Name { get; set; }
        [DisplayName("گروه پدر")]
        public long? ParentId { get; set; }
        [DisplayName("ترتیب نمایش")]
        [Required(ErrorMessage = "ترتیب نمایش گروه را مشخص کنید")]
        public int DisplayOrder { get; set; }
       
        [DisplayName("توضیحات برای سئو")]
        [MaxLength(400, ErrorMessage = "تعداد حروف توضیحات غیر مجاز است")]
        [Required(ErrorMessage = "وارد کردن توضیحات ضروریست")]
        public string Description { get; set; }
        [DisplayName("کلمات کلیدی")]
        [MaxLength(100, ErrorMessage = "تعداد حروف کلمات کلیدی غیر مجاز است")]
        [Required(ErrorMessage = "وارد کردن کلمات کلیدی ضروریست")]
        public string KeyWords { get; set; }
    }
}
