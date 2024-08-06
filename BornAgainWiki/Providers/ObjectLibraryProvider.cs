using BornAgainWiki.Lookup;
using Ronin.Model.Definitions;
using Ronin.Model.Files;
using UnnamedStudios.Common.Repositories.Abstract;
using Zero.Service.Model;

namespace BornAgainWiki.Providers;

public sealed class ObjectLibraryProvider
{
	private readonly ICacheRepository<Task<(ObjectLookup? Lookup, ObjectDefinitionLibrary? Library)>> _resultCache;
	private readonly ILogger<ObjectLibraryProvider> _logger;
	private readonly ApiFileProvider _apiFileProvider;

	public ObjectLibraryProvider(ICacheRepository<Task<(ObjectLookup? Lookup, ObjectDefinitionLibrary? Library)>> resultCache,
		ILogger<ObjectLibraryProvider> logger,
		ApiFileProvider apiFileProvider)
	{
		_resultCache = resultCache;
		_logger = logger;
		_apiFileProvider = apiFileProvider;
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
		return (lookup, library);
	}
}
