using Ronin.Model.Definitions;
using Ronin.Model.Enums;

namespace BornAgainWiki;

public static class ObjectDefinitionExtensions
{
	public static string GetImageSource(this ObjectDefinition definition)
	{
		if (definition.Textures.Length == 0) return string.Empty;
		return $"/tex/{definition.Textures[0]}";
	}

	public static IEnumerable<(StatType StatType, int Increase, int Multiplier)> GetStatIncreases(this ObjectDefinition definition)
	{
		(StatType StatType, int Increase, int Multiplier) getIncrease(ObjectDefinition definition, StatType statType) => (statType, definition.Stats[statType], definition.Multipliers[statType]);

		yield return getIncrease(definition, StatType.Defense);
		yield return getIncrease(definition, StatType.Dexterity);
		yield return getIncrease(definition, StatType.MaxHealth);
		yield return getIncrease(definition, StatType.Speed);
		yield return getIncrease(definition, StatType.Strength);
		yield return getIncrease(definition, StatType.Vigor);
	}

	public static bool HasStatIncreases(this ObjectDefinition definition)
	{
		foreach (var (_, increase, multiplier) in definition.GetStatIncreases())
		{
			if (increase != 0 || multiplier != 0) return true;
		}
		return false;
	}
}
