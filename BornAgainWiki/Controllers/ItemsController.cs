using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspStudio.Models;
using BornAgainWiki.Models.Items;
using Ronin.Model.Definitions;
using BornAgainWiki.Providers;

namespace BornAgainWiki.Controllers;

public class ItemsController : Controller
{
	private readonly GameDataProvider _gameDataProvider;

	public ItemsController(GameDataProvider gameDataProvider)
	{
		_gameDataProvider = gameDataProvider;
	}

	public async Task<IActionResult> Index()
	{
		var library = await _gameDataProvider.GetObjectDefinitionLibraryAsync();
		if (library == null)
		{
			// TODO error
		}

		var model = new ItemsViewModel
		{
			Items = library.All().OfType<ItemDefinition>()
		};

		return View(model);
    }

	[Route("[controller]/{itemName}")]
	public async Task<IActionResult> Item(string itemName)
	{
		// lookup item by name key
		var library = await _gameDataProvider.GetObjectDefinitionLibraryAsync();
		if (library == null)
		{
			// TODO error
		}

		var result = library.Search(itemName, x => x is ItemDefinition).OrderByDescending(x => x.Score).FirstOrDefault();
		var model = new ItemViewModel
		{
			Definition = result.Data as ItemDefinition
		};

		return View(model);
	}
}