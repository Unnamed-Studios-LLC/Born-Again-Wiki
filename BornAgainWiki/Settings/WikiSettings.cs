using UnnamedStudios.Common.Model.Configuration;

namespace BornAgainWiki;

public sealed class WikiSettings : ConfigurationBase
{
	public HttpsSettings Https => GetConfiguration<HttpsSettings>();
	public TtlSettings Ttl => GetConfiguration<TtlSettings>();
	public UrlSettings Url => GetConfiguration<UrlSettings>();
}
