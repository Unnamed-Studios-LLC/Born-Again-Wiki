using BornAgainWiki.Lookup;
using BornAgainWiki.Search;
using Ronin.Model;
using Ronin.Model.Definitions;
using Ronin.Model.Enums;
using Ronin.Model.Files;
using UnnamedStudios.Common.Repositories.Abstract;
using Zero.Service.Model;

namespace BornAgainWiki.Providers;

public sealed class ObjectLibraryProvider
{
	private readonly ICacheRepository<Task<(ObjectLookup? Lookup, ObjectDefinitionLibrary? Library)>> _resultCache;
	private readonly ILogger<ObjectLibraryProvider> _logger;
	private readonly ApiFileProvider _apiFileProvider;
	private readonly SearchEngine _searchEngine;

	private IEnumerable<SearchPage>? _indexedPages;

	public ObjectLibraryProvider(ICacheRepository<Task<(ObjectLookup? Lookup, ObjectDefinitionLibrary? Library)>> resultCache,
		ILogger<ObjectLibraryProvider> logger,
		ApiFileProvider apiFileProvider,
		SearchEngine searchEngine)
	{
		_resultCache = resultCache;
		_logger = logger;
		_apiFileProvider = apiFileProvider;
		_searchEngine = searchEngine;
	}

	public Task<(ObjectLookup? Lookup, ObjectDefinitionLibrary? Library)> GetAsync()
	{
		var settings = ZeroConfiguration.GetConfiguration<WikiSettings>();
		return _resultCache.Get("data", settings.Ttl.Library, LoadAsync);
	}

	public async Task<ObjectDefinitionLibrary?> GetLibraryAsync()
	{
		var (_, library) = await GetAsync();
		return library;
	}

	public async Task<ObjectLookup?> GetLookupAsync()
	{
		var (lookup, _) = await GetAsync();
		return lookup;
	}

	private async Task<(ObjectLookup? Lookup, ObjectDefinitionLibrary? Library)> LoadAsync()
	{
		// get latest file
		var (success, file) = await _apiFileProvider.GetFileAsync("packed.json");
		if (!success ||
			file == null)
		{
			_logger.LogError("Unable to get packed.json");
			return default;
		}

		// parse definition file
		var library = new ObjectDefinitionLibrary();
		using var dataFileStream = File.OpenRead(file.FullName);
		var datas = await ObjectDataFile.LoadAsync(file.FullName, dataFileStream)
			.ConfigureAwait(false);
		library.Add(datas);

		var lookup = new ObjectLookup(library.All());
		await _searchEngine.StartBatchAsync();
		if (_indexedPages != null)
		{
			// remove old indexes
			foreach (var page in _indexedPages)
			{
				await _searchEngine.RemovePageAsync(page);
			}
		}

		var newPages = lookup.Mapping
			.Where(x => x.Value is CharacterDefinition || x.Value is ItemDefinition)
			.Where(x => x.Value.Flags.HasNone(ObjectFlags.Hide))
			.Select(x => new SearchPage(x.Key, x.Value.Name, x.Value.Description, $"/tex/{x.Value.Textures.FirstOrDefault()}"));
		await _searchEngine.AddPagesAsync(newPages);
		_indexedPages = newPages;

		await _searchEngine.CommitBatchAsync();
		return (lookup, library);
	}
}
