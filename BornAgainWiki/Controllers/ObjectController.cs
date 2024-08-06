using BornAgainWiki.Models.Object;
using BornAgainWiki.Providers;
using Microsoft.AspNetCore.Mvc;
using Ronin.Model.Definitions;

namespace BornAgainWiki.Controllers;

public class ObjectController : Controller
{
	private readonly ObjectLibraryProvider _objectLibraryProvider;

	public ObjectController(ObjectLibraryProvider objectLibraryProvider)
	{
		_objectLibraryProvider = objectLibraryProvider;
	}

	public async Task<IActionResult> Object(string itemName)
	{
		// lookup item by name key
		var lookup = await _objectLibraryProvider.GetLookupAsync();
		if (lookup == null)
		{
			// TODO error
			return RedirectToAction("Error", "Home");
		}

		if (!lookup.TryGet(itemName, out var definition))
		{
			// TODO error
			return RedirectToAction("Error", "Home");
		}

		return definition switch
		{
			CharacterDefinition x => Character(x),
			ItemDefinition x => Item(x),
			_ => RedirectToAction("Error", "Home")
		};
	}

	private IActionResult Character(CharacterDefinition definition)
	{
		var model = new CharacterViewModel(definition);
		return View("Character", model);
	}

	private IActionResult Item(ItemDefinition definition)
	{
		var model = new ItemViewModel(definition);
		return View("Item", model);
	}
}
