namespace BornAgainWiki.Lookup;

public sealed class TextureLookup
{
	private readonly Dictionary<string, string> _nameToPathMap;

	public TextureLookup(Dictionary<string, string> nameToPathMap)
	{
		_nameToPathMap = nameToPathMap;
	}

	public bool TryGet(string name, out string? filePath)
	{
		return _nameToPathMap.TryGetValue(name, out filePath);
	}
}
