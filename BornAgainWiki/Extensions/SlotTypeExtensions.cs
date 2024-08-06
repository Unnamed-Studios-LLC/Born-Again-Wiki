using Ronin.Model.Enums;

namespace BornAgainWiki;

public static class SlotTypeExtensions
{
	public static string GetPageName(this SlotType slotType)
	{
		return slotType switch
		{
			SlotType.Dagger => "daggers",
			SlotType.Katana => "katanas",
			SlotType.Sword => "swords",
			_ => slotType.ToString()
		};
	}
}
