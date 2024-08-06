using UnnamedStudios.Common.Model.Configuration;

namespace BornAgainWiki;

public sealed class HttpsSettings : ConfigurationBase
{
	[ConfigKey("Https.CertificatePassword")]
	public string CertificatePassword => GetValue();

	[ConfigKey("Https.CertificatePath")]
	public string CertificatePath => GetValue();
}
