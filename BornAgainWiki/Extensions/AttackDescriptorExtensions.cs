using Ronin.Model.Classes;

namespace BornAgainWiki;

public static class AttackDescriptorExtensions
{
	public static string GetImageSource(this AttackDescriptor attackDescriptor)
	{
		if (attackDescriptor.Textures.Length == 0) return string.Empty;
		return $"/tex/{attackDescriptor.Textures[0]}";
	}
}
