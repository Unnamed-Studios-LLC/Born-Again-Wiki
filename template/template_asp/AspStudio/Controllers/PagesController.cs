using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspStudio.Models;

namespace AspStudio.Controllers;

public class PagesController : Controller
{
		public IActionResult ScrumBoard()
		{
				return View();
		}
		
		public IActionResult Products()
		{
				return View();
		}
		
		public IActionResult ProductDetails()
		{
				return View();
		}
		
		public IActionResult Orders()
		{
				return View();
		}
		
		public IActionResult OrderDetails()
		{
				return View();
		}
		
		public IActionResult Gallery()
		{
				return View();
		}

		public IActionResult SearchResults()
		{
				return View();
		}

		public IActionResult ComingSoonPage()
		{
				return View();
		}

		public IActionResult ErrorPage()
		{
				return View();
		}

		public IActionResult Login()
		{
				return View();
		}

		public IActionResult Register()
		{
				return View();
		}

		public IActionResult Messenger()
		{
				return View();
		}

		public IActionResult DataManagement()
		{
				return View();
		}

		public IActionResult FileManager()
		{
				return View();
		}

		public IActionResult PricingPage()
		{
				return View();
		}
}
