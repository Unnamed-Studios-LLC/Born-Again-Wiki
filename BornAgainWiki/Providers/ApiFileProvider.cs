using Ronin.Api.Model;
using System.IO.Compression;
using UnnamedStudios.Common.Model;
using UnnamedStudios.Common.Providers;

namespace BornAgainWiki.Providers;

public sealed class ApiFileProvider
{
	private readonly RoninApiClient _client;
	private readonly ILogger<ObjectLibraryProvider> _logger;
	private readonly TemporaryDiskStorageProvider _temporaryDiskStorageProvider;

	public ApiFileProvider(RoninApiClient client,
		ILogger<ObjectLibraryProvider> logger,
		TemporaryDiskStorageProvider temporaryDiskStorageProvider)
	{
		_client = client;
		_logger = logger;
		_temporaryDiskStorageProvider = temporaryDiskStorageProvider;
	}

	public async Task<(bool Success, FileInfo? File)> GetFileAsync(string resourceName)
	{
		// download file
		var response = await _client.DataFetchAsync(resourceName);
		if (!response.Successful)
		{
			_logger.LogError("Failed to download {0}: {1}: {2}", resourceName, response.StatusCode, response.Error);
			return (false, null);
		}

		var file = _temporaryDiskStorageProvider.New(resourceName);
		var directory = _temporaryDiskStorageProvider.NewDirectory(Guid.NewGuid().ToString());

		try
		{
			// decompress zip
			if (!directory.Exists)
			{
				directory.Create();
			}

			ZipFile.ExtractToDirectory(response.Object, directory.FullName);

			// find extracted file
			var extractedFile = Directory.EnumerateFiles(directory.FullName, "*", SearchOption.AllDirectories).FirstOrDefault();
			if (extractedFile == null)
			{
				_logger.LogError("Failed to download {0}: No file found in ZipArchive", resourceName);
				return (false, null);
			}

			// move file out of directory
			File.Move(extractedFile, file.FullName, true);
			return (true, file);
		}
		finally
		{
			directory.Delete(true);
		}
	}
}
