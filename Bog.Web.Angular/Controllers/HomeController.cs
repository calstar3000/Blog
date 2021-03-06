﻿using Microsoft.AspNet.Mvc;

namespace Bog.Web.Angular.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Publish()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Error()
		{
			return View();
		}
	}
}
