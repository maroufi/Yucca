using System;

namespace Yucca.Models.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}