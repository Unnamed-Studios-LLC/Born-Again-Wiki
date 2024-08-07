using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspStudio.Models;

namespace AspStudio.Controllers;

public class FormsController : Controller
{
		public IActionResult FormElements()
		{
				return View();
		}

		public IActionResult FormPlugins()
		{
				return View();
		}

		public IActionResult Wizards()
		{
				return View();
		}
}