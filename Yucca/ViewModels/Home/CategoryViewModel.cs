using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yucca.ViewModels.Home
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public bool IsDeleted { get; set; } = false;
        public long? ParentId { get; set; }
    }
}