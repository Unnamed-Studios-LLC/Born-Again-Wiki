﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspStudio.Models;

namespace AspStudio.Controllers;

public class LandingController : Controller
{
		public IActionResult Index()
		{
				return View();
		}
}
