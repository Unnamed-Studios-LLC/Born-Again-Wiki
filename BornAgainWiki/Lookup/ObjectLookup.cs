using Ronin.Model;
using Ronin.Model.Cache;
using Ronin.Model.Definitions;

namespace BornAgainWiki.Lookup;

public sealed class ObjectLookup
{
	private readonly Dictionary<string, ObjectDefinition> _mapping = new();

	public IReadOnlyDictionary<string, ObjectDefinition> Mapping => _mapping;

	public ObjectLookup(IEnumerable<ObjectDefinition> definitions)
	{
		foreach (var definition in definitions)
		{
			_mapping[GenerateKey(definition.Name)] = definition;
		}
	}

	public static string GenerateKey(string name)
	{
		var builder = StringBuilderCache.Get();
		builder.Append(name);
		builder.ToLower();
		builder.Replace(' ', '_');
		builder.Replace("'", "");
		return StringBuilderCache.Complete(builder);
	}

	public bool TryGet(string key, out ObjectDefinition? definition)
	{
		return _mapping.TryGetValue(key, out definition);
	}
}
