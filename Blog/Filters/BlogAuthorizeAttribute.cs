using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Blog.Filters
{
	public class BlogAuthorizeAttribute : AuthorizationFilterAttribute
	{
		public override void OnAuthorization(HttpActionContext actionContext)
		{
			var authHeader = actionContext.Request.Headers.Authorization;

			if (authHeader != null)
			{
				if (authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
					!string.IsNullOrEmpty(authHeader.Parameter))
				{
					var rawCredentials = authHeader.Parameter;
					var encoding = Encoding.GetEncoding("iso-8859-1");
					var credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));
					var split = credentials.Split(':');
					var username = split[0];
					var password = split[1];

					// TDOD: implement authorization
				}
			}

			HandleUnauthorized(actionContext);
		}

		private void HandleUnauthorized(HttpActionContext actionContext)
		{
			actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
			actionContext.Response.Headers.Add("WWW-Authenticate", "Basic Scheme='Blog' location='http://localhost:54905/account/login'");
		}
	}
}