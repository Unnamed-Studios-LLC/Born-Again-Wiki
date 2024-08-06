using Microsoft.AspNetCore.Mvc;
using BornAgainWiki.Models.Items;
using Ronin.Model.Definitions;
using BornAgainWiki.Providers;
using Ronin.Model.Enums;

namespace BornAgainWiki.Controllers;

public class ItemsController : Controller
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

	[Route("daggers")]
	public async Task<IActionResult> Daggers()
	{
		return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Dagger));
	}

	[Route("katanas")]
	public async Task<IActionResult> Katanas()
	{
		return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Katana));
	}

	[Route("swords")]
	public async Task<IActionResult> Swords()
	{
		return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Sword));
	}

	private async Task<IActionResult> ItemViewAsync(Func<IEnumerable<ItemDefinition>, IEnumerable<ItemDefinition>>? filter = null)
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