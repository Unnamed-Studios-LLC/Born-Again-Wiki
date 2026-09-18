using Ronin.Model.Definitions;

namespace BornAgainWiki.Models.Object;

public sealed class EnemyViewModel
{
    public EnemyDefinition Definition { get; }

    public EnemyViewModel(EnemyDefinition definition)
    {
        Definition = definition;
    }
}
