﻿using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Blog.API
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
		}

		protected void Application_BeginRequest()
		{
			if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
			{
				Response.Flush();
			}
		}
	}
}
