﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspStudio.Models;

namespace AspStudio.Controllers;

public class MapController : Controller
{
		public IActionResult Index()
		{
				return View();
		}
}
