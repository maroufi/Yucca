using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Yucca.Areas.Admin.ViewModels.Attribute
{
    public class AttributeViewModel
    {
        public long Id { get; set; }
        [DisplayName("نام خصوصیت")]
        public String Name { get; set; }
        [DisplayName("گروه کالا مربوطه")]
        public long CategoryId { get; set; }
    }
}