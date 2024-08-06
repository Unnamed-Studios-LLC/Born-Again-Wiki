using Ronin.Model.Definitions;

namespace BornAgainWiki.Models.Object;

public sealed class ItemViewModel
{
    public ItemDefinition Definition { get; }

    public ItemViewModel(ItemDefinition definition)
    {
        Definition = definition;
    }
}
