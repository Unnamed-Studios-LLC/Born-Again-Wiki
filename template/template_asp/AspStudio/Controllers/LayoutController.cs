using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspStudio.Models;

namespace AspStudio.Controllers;

public class LayoutController : Controller
{
		public IActionResult StarterPage()
		{
				return View();
		}

		public IActionResult FixedFooter()
		{
				return View();
		}

		public IActionResult FullHeight()
		{
				return View();
		}

		public IActionResult FullWidth()
		{
				return View();
		}

		public IActionResult BoxedLayout()
		{
				return View();
		}

		public IActionResult MinifiedSidebar()
		{
				return View();
		}

		public IActionResult TopNav()
		{
				return View();
		}

		public IActionResult MixedNav()
		{
				return View();
		}

		public IActionResult MixedNavBoxedLayout()
		{
				return View();
		}
}
