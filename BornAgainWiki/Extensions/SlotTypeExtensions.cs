using Ronin.Model.Enums;

namespace BornAgainWiki;

public static class SlotTypeExtensions
{
	public static string GetPageName(this SlotType slotType)
	{
		return slotType switch
		{
			SlotType.Accessory => "accessories",
			SlotType.Armor => "armors",
			SlotType.Boots => "boots",
			SlotType.Bow => "bows",
			SlotType.Dagger => "daggers",
			SlotType.Hammer => "hammers",
			SlotType.Katana => "katanas",
			SlotType.Kunai => "kunai",
			SlotType.Robe => "robes",
			SlotType.Staff => "staves",
			SlotType.Sword => "swords",
			SlotType.Tabi => "tabi",
			SlotType.Tekko => "tekko",
			_ => slotType.ToString().ToLower()
		};
	}
}
