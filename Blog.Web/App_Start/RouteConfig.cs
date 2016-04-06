using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "New Post",
				url: "posts/new",
				defaults: new { controller = "Home", action = "New" }
			);

			routes.MapRoute(
				name: "Register",
				url: "register",
				defaults: new { controller = "Home", action = "Register" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
