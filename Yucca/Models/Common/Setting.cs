namespace Yucca.Models.Common
{
    public class Setting:BaseEntity
    {
        #region Properties
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }

        #endregion
    }
}
