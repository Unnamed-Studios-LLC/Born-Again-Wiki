using Microsoft.AspNetCore.Mvc;
using BornAgainWiki.Models.Items;
using Ronin.Model.Definitions;
using BornAgainWiki.Providers;
using Ronin.Model.Enums;

namespace BornAgainWiki.Controllers;

public abstract class ItemsController : Controller
{
	private readonly ObjectLibraryProvider _objectLibraryProvider;

	public ItemsController(ObjectLibraryProvider objectLibraryProvider)
	{
		_objectLibraryProvider = objectLibraryProvider;
	}

	public async Task<IActionResult> Index()
	{
		return await ItemViewAsync();
	}

	protected async Task<IActionResult> ItemViewAsync(Func<IEnumerable<ItemDefinition>, IEnumerable<ItemDefinition>>? filter = null)
	{
		var library = await _objectLibraryProvider.GetLibraryAsync();
		if (library == null)
		{
			// TODO error
			return RedirectToAction("Error", "Home");
		}

		var items = library.All().OfType<ItemDefinition>();
		if (filter != null) items = filter(items);
		var model = new ItemsViewModel(items);
		return View(model);
	}
}