using BornAgainWiki.Providers;
using Microsoft.AspNetCore.Mvc;
using Ronin.Model.Enums;

namespace BornAgainWiki.Controllers
{
	public class WeaponsController : ItemsController
	{
		public WeaponsController(ObjectLibraryProvider objectLibraryProvider) : base(objectLibraryProvider)
		{
		}

		[Route("bows")]
		public async Task<IActionResult> Bows()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Bow));
		}

		[Route("daggers")]
		public async Task<IActionResult> Daggers()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Dagger));
		}

		[Route("hammers")]
		public async Task<IActionResult> Hammers()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Hammer));
		}

		[Route("katanas")]
		public async Task<IActionResult> Katanas()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Katana));
		}

		[Route("kunai")]
		public async Task<IActionResult> Kunai()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Kunai));
		}

		[Route("staves")]
		public async Task<IActionResult> Staves()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Staff));
		}

		[Route("swords")]
		public async Task<IActionResult> Swords()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Sword));
		}

		[Route("tekko")]
		public async Task<IActionResult> Tekko()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Tekko));
		}
	}
}
