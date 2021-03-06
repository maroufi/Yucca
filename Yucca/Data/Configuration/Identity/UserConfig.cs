﻿using System.Data.Entity.ModelConfiguration;
using Yucca.Models.IdentityModels;

namespace Yucca.Data.Configuration.Identity
{
    public class UserConfig:EntityTypeConfiguration<YuccaUser>
    {
        public UserConfig()
        {
            HasMany(a=>a.Addresses)
                .WithRequired(a=>a.User)
                .WillCascadeOnDelete(true);
            HasMany(a=>a.Orders)
                .WithRequired(a=>a.Buyer)
                .WillCascadeOnDelete(true);
            Property(a => a.Email).HasMaxLength(50).IsRequired();
            Property(a => a.AvatarPath).HasMaxLength(200).IsOptional();
            Property(a => a.FirstName).HasMaxLength(50).IsOptional();
            Property(a => a.Ip).HasMaxLength(20).IsOptional();
            Property(a => a.LastName).HasMaxLength(50).IsOptional();
            Property(a => a.PhoneNumber).HasMaxLength(20).IsOptional();
            Property(a => a.RowVersion).IsRowVersion();
            Property(a => a.UserName).HasMaxLength(50).IsRequired();
            Property(a => a.BannedDate).IsOptional();
            Property(a => a.BirthDay).IsOptional();

        }
    }
}
