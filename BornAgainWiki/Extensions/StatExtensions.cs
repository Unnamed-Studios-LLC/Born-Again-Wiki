using Ronin.Model.Enums;
using Ronin.Model.Structs;

namespace BornAgainWiki;

public static class StatExtensions
{
	public static IEnumerable<(StatType StatType, int Stat)> All(this Stats stats)
	{
		(StatType StatType, int Stat) getIncrease(Stats stats, StatType statType) => (statType, stats[statType]);

		yield return getIncrease(stats, StatType.Defense);
		yield return getIncrease(stats, StatType.Dexterity);
		yield return getIncrease(stats, StatType.MaxHealth);
		yield return getIncrease(stats, StatType.Speed);
		yield return getIncrease(stats, StatType.Strength);
		yield return getIncrease(stats, StatType.Vigor);
	}
}
