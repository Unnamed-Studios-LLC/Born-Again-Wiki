using Ronin.Model.Definitions;

namespace BornAgainWiki.Models.Object;

public sealed class CharacterViewModel
{
	public CharacterDefinition Definition { get; }

	public CharacterViewModel(CharacterDefinition definition)
	{
		Definition = definition;
	}
}
