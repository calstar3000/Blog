﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Blog.API.Startup))]

namespace Blog.API
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
