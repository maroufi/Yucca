﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Yucca.Startup))]
namespace Yucca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
