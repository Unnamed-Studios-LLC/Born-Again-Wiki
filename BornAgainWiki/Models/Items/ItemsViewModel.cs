using Ronin.Model.Definitions;

namespace BornAgainWiki.Models.Items;

public sealed class ItemsViewModel
{
	public IEnumerable<ItemDefinition> Items { get; }

	public ItemsViewModel(IEnumerable<ItemDefinition> items)
	{
		Items = items;
	}
}
