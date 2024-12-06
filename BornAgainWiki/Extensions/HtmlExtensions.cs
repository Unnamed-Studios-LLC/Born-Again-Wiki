using BornAgainWiki.Models.Shared;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ronin.Model.Definitions;
using Ronin.Model.GameActions;
using Ronin.Model.Modifiers;

namespace BornAgainWiki.Extensions
{
	public static class HtmlExtensions
	{
		public static async Task<IHtmlContent> GameActionsAsync(this IHtmlHelper htmlHelper, IEnumerable<GameAction>? actions, ObjectDefinition? definition, bool constant = false, float scalar = 1)
		{
			return await htmlHelper.PartialAsync("_GameAction", new GameActionViewModel(actions, definition, false, constant, scalar));
		}

		public static async Task<IHtmlContent> GameActionsAsync(this IHtmlHelper htmlHelper, GameActionViewModel model)
		{
			return await htmlHelper.PartialAsync("_GameAction", model);
		}

		public static async Task<IHtmlContent> ModifiersAsync(this IHtmlHelper htmlHelper, IEnumerable<Modifier>? modifiers, ObjectDefinition? definition, float charge = 0)
		{
			return await htmlHelper.PartialAsync("_Modifier", new ModifierViewModel(modifiers, definition, charge));
		}

		public static async Task<IHtmlContent> ModifiersAsync(this IHtmlHelper htmlHelper, ModifierViewModel model)
		{
			return await htmlHelper.PartialAsync("_Modifier", model);
		}
	}
}
