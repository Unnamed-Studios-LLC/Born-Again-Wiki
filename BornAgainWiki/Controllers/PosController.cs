using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspStudio.Models;

namespace AspStudio.Controllers;

public class PosController : Controller
{
		public IActionResult CustomerOrder()
		{
				return View();
		}

		public IActionResult KitchenOrder()
		{
				return View();
		}

		public IActionResult CounterCheckout()
		{
				return View();
		}

		public IActionResult TableBooking()
		{
				return View();
		}

		public IActionResult MenuStock()
		{
				return View();
		}
}