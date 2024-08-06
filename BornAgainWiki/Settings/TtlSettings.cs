using UnnamedStudios.Common.Model.Configuration;

namespace BornAgainWiki;

public sealed class TtlSettings : ConfigurationBase
{
	[ConfigKey("Ttl.Library")]
	public int Library => GetIntValue();

	[ConfigKey("Ttl.Texture")]
	public int Texture => GetIntValue();
}