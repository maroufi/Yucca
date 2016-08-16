﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Yucca.Models.IdentityModels
{
    public class YuccaUserLogin : IdentityUserLogin<long> { }
    public class YuccaUserClaim : IdentityUserClaim<long> { }
    public class YuccaUserRole : IdentityUserRole<long> { }

    public class YuccaRole : IdentityRole<long, YuccaUserRole>, IRole<long>
    {
        public YuccaRole() { }

        public YuccaRole(string name)
        {
            this.Name = name;
        }

        public YuccaRole(string name, string description) : this(name)
        {
            this.Description = description;
        }
        public string Description { get; set; }
        public new ICollection<YuccaUser> Users { get; set; } 

    }
}