using BornAgainWiki.Providers;
using Microsoft.AspNetCore.Mvc;
using Ronin.Model.Enums;

namespace BornAgainWiki.Controllers
{
	public class EquipmentController : ItemsController
	{
		public EquipmentController(ObjectLibraryProvider objectLibraryProvider) : base(objectLibraryProvider)
		{
		}

		[Route("accessories")]
		public async Task<IActionResult> Accessories()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Accessory));
		}

		[Route("armors")]
		public async Task<IActionResult> Armors()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Armor));
		}

		[Route("boots")]
		public async Task<IActionResult> Boots()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Boots));
		}

		[Route("robes")]
		public async Task<IActionResult> Robes()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Robe));
		}

		[Route("tabi")]
		public async Task<IActionResult> Tabi()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Tabi));
		}
	}
}
