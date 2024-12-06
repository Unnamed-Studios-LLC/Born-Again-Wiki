using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspStudio.Models;

namespace AspStudio.Controllers;

public class ChartsController : Controller
{
		public IActionResult ChartJs()
		{
				return View();
		}

		public IActionResult ApexchartsJs()
		{
				return View();
		}
}
