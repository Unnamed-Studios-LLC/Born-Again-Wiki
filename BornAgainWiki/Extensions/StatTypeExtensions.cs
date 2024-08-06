using Ronin.Model.Enums;

namespace BornAgainWiki;

public static class StatTypeExtensions
{
	public static string FormatStat(this StatType statType, int stat)
	{
		var partial = statType switch
		{
			StatType.Dexterity or StatType.Vigor => true,
			_ => false
		};

		if (!partial) return stat.ToString();

		return (MathF.Ceiling(stat / 10f) / 10f).ToString("0.0");
	}
}
