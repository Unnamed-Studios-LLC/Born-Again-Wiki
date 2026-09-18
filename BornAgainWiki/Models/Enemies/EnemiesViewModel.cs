using Ronin.Model.Definitions;

namespace BornAgainWiki.Models.Enemies;

public sealed class EnemiesViewModel 
    {
    public IEnumerable<EnemyDefinition> Enemies { get; }

    public EnemiesViewModel(IEnumerable<EnemyDefinition> enemies) 
    {
        Enemies = enemies;
    }
}
