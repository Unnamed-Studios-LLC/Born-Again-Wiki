﻿using BornAgainWiki.Lookup;
using Ronin.Model.Files;
using Ronin.Model.Files.Animation;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using UnnamedStudios.Common.Providers;
using UnnamedStudios.Common.Repositories.Abstract;
using Zero.Service.Model;

namespace BornAgainWiki.Providers
{
	public sealed class TextureProvider
	{
		private readonly ICacheRepository<Task<TextureLookup?>> _resultCache;
		private readonly ApiFileProvider _apiFileProvider;
		private readonly ILogger<TextureProvider> _logger;
		private readonly TemporaryDiskStorageProvider _temporaryDiskStorageProvider;

		public TextureProvider(ICacheRepository<Task<TextureLookup?>> resultCache,
			ApiFileProvider apiFileProvider,
			ILogger<TextureProvider> logger,
			TemporaryDiskStorageProvider temporaryDiskStorageProvider)
		{
			_resultCache = resultCache;
			_apiFileProvider = apiFileProvider;
			_logger = logger;
			_temporaryDiskStorageProvider = temporaryDiskStorageProvider;
		}

		public Task<TextureLookup?> GetLookupAsync()
		{
			var settings = ZeroConfiguration.GetConfiguration<WikiSettings>();
			return _resultCache.Get("texture", settings.Ttl.Texture, LoadAsync);
		}

		private async Task<TextureLookup?> LoadAsync()
		{
			// get packed png file
			bool success;
			FileInfo? pngFile, animFile;

			(success, pngFile) = await _apiFileProvider.GetFileAsync("packed.png");
			if (!success ||
				pngFile == null)
			{
				_logger.LogError("Unable to get packed.png");
				return default;
			}

			(success, animFile) = await _apiFileProvider.GetFileAsync("packed.anim");
			if (!success ||
				animFile == null)
			{
				_logger.LogError("Unable to get packed.anim");
				return default;
			}

			var switches = await AnimationFile.LoadJsonAsync(animFile.FullName);
			var sourceImage = await Image.LoadAsync<Rgba32>(pngFile.FullName);
			var namePathMap = new Dictionary<string, TextureLookup.Entry>();
			foreach (var @switch in switches)
			{
				var file = _temporaryDiskStorageProvider.New(@switch.Name);
				var loop = @switch.Loops.FirstOrDefault(x => x.Phase == AnimationPhase.Slot) ?? @switch.Loops.FirstOrDefault(x => x.Phase == AnimationPhase.Still) ?? @switch.Loops.FirstOrDefault();
				if (loop == null) return default;
				var frame = loop.Frames.FirstOrDefault();
				if (frame == null) return default;
				var region = new Rectangle(frame.X, sourceImage.Height - frame.Y - frame.Height, frame.Width, frame.Height);
				var croppedImage = sourceImage.Clone(ctx => ctx.Crop(region));

				var name = @switch.Name.ToLowerInvariant();
				var entry = new TextureLookup.Entry(region, file.FullName);
				namePathMap[name] = entry;
			}
			var lookup = new TextureLookup(sourceImage, namePathMap);
			return lookup;
		}
	}
}
