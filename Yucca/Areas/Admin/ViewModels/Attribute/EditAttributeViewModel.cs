using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Yucca.Areas.Admin.ViewModels.Attribute
{
    public class EditAttributeViewModel
    {
        [DisplayName("نام")]
        [Required(ErrorMessage = "وارد کردن نام خصوصیات ضروریست")]
        [MaxLength(40, ErrorMessage = "تعداد حروف نام خصوصیت غیر مجاز است")]
        [Remote("EditCheckExistAttributeForCategory", "Category", "Admin", ErrorMessage = "این ویژگی قبلا برای این گروه ثبت شده است", HttpMethod = "POST", AdditionalFields = "CategoryId,Id")]
        public string Name { get; set; }
        public long Id { get; set; }
        public long CategoryId { get; set; }
        [DisplayName("تغییر برای فرزندان")]
        public bool CascadeAddForChildren { get; set; }
    }
}
