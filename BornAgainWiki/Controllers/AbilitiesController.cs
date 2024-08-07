using BornAgainWiki.Providers;
using Microsoft.AspNetCore.Mvc;
using Ronin.Model.Enums;

namespace BornAgainWiki.Controllers
{
	public class AbilitiesController : ItemsController
	{
		public AbilitiesController(ObjectLibraryProvider objectLibraryProvider) : base(objectLibraryProvider)
		{
		}

		[Route("agility")]
		public async Task<IActionResult> Agility()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Ability && x.Ability.Style == AbilityStyle.Agility));
		}

		[Route("focus")]
		public async Task<IActionResult> Focus()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Ability && x.Ability.Style == AbilityStyle.Focus));
		}

		[Route("power")]
		public async Task<IActionResult> Power()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Ability && x.Ability.Style == AbilityStyle.Power));
		}

		[Route("support")]
		public async Task<IActionResult> Support()
		{
			return await ItemViewAsync(x => x.Where(x => x.SlotType == SlotType.Ability && x.Ability.Style == AbilityStyle.Support));
		}
	}
}
