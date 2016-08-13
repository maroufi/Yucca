using System.ComponentModel;

namespace Yucca.Areas.Admin.ViewModels.Attribute
{
   public class DeleteAttributeViewModel
    {
       public long Id { get; set; }
       [DisplayName("نام خصوصیت")]
       public string  Name { get; set; }
       public long  CategoryId { get; set; }
       [DisplayName("حذف ویژگی از گروه های فرزند")]
       public bool CascadeDeleteForChildrenCategory { get; set; }

    }
}
