using System;

namespace Yucca.Models.Common
{
    public class BaseEntity
    {
        public virtual long Id { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }

    }
}