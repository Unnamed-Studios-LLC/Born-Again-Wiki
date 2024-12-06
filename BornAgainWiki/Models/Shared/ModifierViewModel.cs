using Ronin.Model.Definitions;
using Ronin.Model.Modifiers;

namespace BornAgainWiki.Models.Shared
{
	public sealed class ModifierViewModel
	{
		public ModifierViewModel(IEnumerable<Modifier>? modifiers,
			ObjectDefinition? definition,
			float charge)
		{
			Modifiers = modifiers;
			Definition = definition;
			Charge = charge;
		}

		public IEnumerable<Modifier>? Modifiers { get; }
		public ObjectDefinition? Definition { get; }
		public float Charge { get; }
	}
}
