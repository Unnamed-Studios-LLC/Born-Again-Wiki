using Ronin.Model.Enums;

namespace BornAgainWiki
{
	public static class EnumLanguageExtensions
	{
		public static string GetLanguage(this StatusEffects statusEffect)
		{
			return statusEffect switch
			{
				StatusEffects.Healing => "Healing I",
				StatusEffects.Healing2 => "Healing II",
				StatusEffects.Healing3 => "Healing III",
				StatusEffects.Armored => "Armored I",
				StatusEffects.Armored2 => "Armored II",
				StatusEffects.Armored3 => "Armored III",
				StatusEffects.Fury => "Fury I",
				StatusEffects.Fury2 => "Fury II",
				StatusEffects.Fury3 => "Fury III",
				StatusEffects.Empowered => "Empowered I",
				StatusEffects.Empowered2 => "Empowered II",
				StatusEffects.Empowered3 => "Empowered III",
				StatusEffects.Speedy => "Speedy I",
				StatusEffects.Speedy2 => "Speedy II",
				StatusEffects.Speedy3 => "Speedy III",
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
				TriggerEvent.Healing => "Healing I",
				TriggerEvent.Healing2 => "Healing II",
				TriggerEvent.Healing3 => "Healing III",
				TriggerEvent.Armored => "Armored I",
				TriggerEvent.Armored2 => "Armored II",
				TriggerEvent.Armored3 => "Armored III",
				TriggerEvent.Fury => "Fury I",
				TriggerEvent.Fury2 => "Fury II",
				TriggerEvent.Fury3 => "Fury III",
				TriggerEvent.Empowered => "Empowered I",
				TriggerEvent.Empowered2 => "Empowered II",
				TriggerEvent.Empowered3 => "Empowered III",
				TriggerEvent.Speedy => "Speedy I",
				TriggerEvent.Speedy2 => "Speedy II",
				TriggerEvent.Speedy3 => "Speedy III",
				TriggerEvent.AbilityAbility => "Ability Use",
				TriggerEvent.AbilityWeapon => "Weapon Use",
				_ => triggerEvent.ToString()
			};
		}
	}
}
