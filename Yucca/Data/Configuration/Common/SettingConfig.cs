using System.Data.Entity.ModelConfiguration;
using Yucca.Models.Common;

namespace Yucca.Data.Configuration.Common
{
    public class SettingConfig:EntityTypeConfiguration<Setting>
    {
        public SettingConfig()
        {
            Property(a => a.Name).HasMaxLength(100).IsRequired();
            Property(a => a.Value).HasMaxLength(100).IsRequired();
        }
    }
}
