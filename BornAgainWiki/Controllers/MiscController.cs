using BornAgainWiki.Providers;
using Microsoft.AspNetCore.Mvc;
using Ronin.Model.Definitions;
using Ronin.Model.Enums;

namespace BornAgainWiki.Controllers
{
	public class MiscController : ItemsController
	{
		public MiscController(ObjectLibraryProvider objectLibraryProvider) : base(objectLibraryProvider)
		{
		}

		[Route("general")]
		public async Task<IActionResult> General()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.General));
		}

		[Route("food")]
		public async Task<IActionResult> Food()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Food));
		}

		[Route("hats")]
		public async Task<IActionResult> Hats()
		{
			return await ItemViewAsync(x => x.Where(x => x is HatDefinition));
		}

		[Route("blessings")]
		public async Task<IActionResult> Blessings()
		{
			return await ItemViewAsync(x => x.Where(x => x is BlessingDefinition blessingDefinition && blessingDefinition.BlessingStyle == BlessingStyle.Standard));
		}
	}
}