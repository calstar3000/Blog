﻿using System.Web.Mvc;

namespace Blog.Web.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Archive()
		{
			return View();
		}

		public ActionResult Register()
		{
			return View();
		}
	}
}