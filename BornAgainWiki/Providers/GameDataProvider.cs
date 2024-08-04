using Ronin.Api.Model;
using Ronin.Model.Definitions;
using Ronin.Model.Files;
using System.IO.Compression;
using UnnamedStudios.Common.Providers;
using UnnamedStudios.Common.Repositories.Abstract;

namespace BornAgainWiki.Providers;

public sealed class GameDataProvider
{
	private readonly ICacheRepository<Task<ObjectDefinitionLibrary>> _libraryCacheProvider;
	private readonly RoninApiClient _client;
	private readonly ILogger<GameDataProvider> _logger;
	private readonly TemporaryDiskStorageProvider _temporaryDiskStorageProvider;

	public GameDataProvider(ICacheRepository<Task<ObjectDefinitionLibrary>> libraryCacheProvider,
		RoninApiClient client,
		ILogger<GameDataProvider> logger,
		TemporaryDiskStorageProvider temporaryDiskStorageProvider)
	{
		_libraryCacheProvider = libraryCacheProvider;
		_client = client;
		_logger = logger;
		_temporaryDiskStorageProvider = temporaryDiskStorageProvider;
	}

	public Task<ObjectDefinitionLibrary> GetObjectDefinitionLibraryAsync()
	{
		return _libraryCacheProvider.Get("data", 60, LoadDefinitionLibraryAsync);
	}

	private async Task<ObjectDefinitionLibrary> LoadDefinitionLibraryAsync()
	{
		// download files
		// TODO retry/failure logic
		var response = await _client.DataFetchAsync("packed.json");
		if (!response.Successful)
		{
			_logger.LogError("Failed to download packed.json: {0}: {1}", response.StatusCode, response.Error);
			return null;
		}

		var library = new ObjectDefinitionLibrary();
		var jsonDirectory = _temporaryDiskStorageProvider.NewDirectory(Guid.NewGuid().ToString());

		try
		{
			// decompress zip
			if (!jsonDirectory.Exists)
			{
				jsonDirectory.Create();
			}

			ZipFile.ExtractToDirectory(response.Object, jsonDirectory.FullName);

			// parse file
			foreach (var dataFilePath in Directory.EnumerateFiles(jsonDirectory.FullName, "*", SearchOption.AllDirectories))
			{
				try
				{
					using var dataFileStream = File.OpenRead(dataFilePath);
					var datas = await ObjectDataFile.LoadAsync(dataFilePath, dataFileStream)
						.ConfigureAwait(false);
					library.Add(datas);
				}
				catch (Exception e)
				{
					_logger.LogError(e, $"Failed to load data file: {dataFilePath}");
				}
			}
		}
		finally
		{
			jsonDirectory.Delete(true);
		}

		return library;
	}
}
