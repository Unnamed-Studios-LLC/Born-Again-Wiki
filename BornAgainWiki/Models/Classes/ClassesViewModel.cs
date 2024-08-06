using Ronin.Model.Definitions;

namespace BornAgainWiki.Models.Classes;

public sealed class ClassesViewModel
{
	public IEnumerable<CharacterDefinition> Characters { get; }

	public ClassesViewModel(IEnumerable<CharacterDefinition> characters)
	{
		Characters = characters;
	}
}
