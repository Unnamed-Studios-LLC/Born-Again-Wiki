using Ronin.Model.Enums;

namespace BornAgainWiki
{
	public static class EnumLanguageExtensions
	{
		public static string GetLanguage(this StatusEffects statusEffect)
		{
			return statusEffect switch
			{
				_ => statusEffect.ToString()
			};
		}

		public static string GetLanguage(this TriggerEvent triggerEvent)
		{
			return triggerEvent switch
			{
				TriggerEvent.KilledEnemy => "Enemy Kill",
				TriggerEvent.AbilityBoots => "Boots Use",
				TriggerEvent.FoodConsumed => "Food Consumed",
				TriggerEvent.Empowered => "Empowered I",
				TriggerEvent.Empowered2 => "Empowered II",
				TriggerEvent.Empowered3 => "Empowered III",
				TriggerEvent.AbilityAbility => "Ability Use",
				TriggerEvent.AbilityWeapon => "Weapon Use",
				_ => triggerEvent.ToString()
			};
		}
	}
}
