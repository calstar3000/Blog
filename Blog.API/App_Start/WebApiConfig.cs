using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using Blog.API.Filters;

namespace Blog.API
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			// Configure Web API to use only bearer token authentication.
			config.SuppressDefaultHostAuthentication();
			config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

#if !DEBUG
			// Force HTTPS on entire API
			config.Filters.Add(new RequireHttpsAttribute());
#endif

			// Web API routes
			config.MapHttpAttributeRoutes();

			// Return JSON by default
			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			config.Routes.MapHttpRoute(
				name: "Post",
				routeTemplate: "api/blog/posts/{postId}",
				defaults: new { controller = "posts", postId = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "Comment",
				routeTemplate: "api/blog/posts/{postId}/comments/{commentId}",
				defaults: new { controller = "comments", commentId = RouteParameter.Optional }
			);
		}
	}
}
