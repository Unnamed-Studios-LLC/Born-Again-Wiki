using Ronin.Model.Enums;

namespace BornAgainWiki;

public static class EnemyArchetypeExtensions {
    public static string GetPageName(this EnemyArchetype enemyArchetype) {
        return enemyArchetype switch {
            EnemyArchetype.Encounter => "bosses",
            EnemyArchetype.EncounterMinion => "bosses",
            EnemyArchetype.CampLeader => "camp_leaders",
            EnemyArchetype.Minion => "minions",
            _ => enemyArchetype.ToString().ToLower()
        };
    }
}