using System.ComponentModel;

namespace Yucca.Areas.Admin.ViewModels.Category
{
    public class CategoryViewModel
    {
        public virtual long Id { get; set; }
        [DisplayName("نام گروه")]
        public virtual string Name { get; set; }
    }
}
