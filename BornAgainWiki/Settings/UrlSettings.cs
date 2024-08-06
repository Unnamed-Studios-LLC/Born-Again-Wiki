using UnnamedStudios.Common.Model.Configuration;

namespace BornAgainWiki;

public sealed class UrlSettings : ConfigurationBase
{
	[ConfigKey("Url.BornAgainApi")]
	public string BornAgainApi => GetValue();
}
