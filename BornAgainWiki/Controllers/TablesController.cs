using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspStudio.Models;

namespace AspStudio.Controllers;

public class TablesController : Controller
{
		public IActionResult TableElements()
		{
				return View();
		}

		public IActionResult TablePlugins()
		{
				return View();
		}
}