using BornAgainWiki.Enums;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Collections.Concurrent;

namespace BornAgainWiki.Lookup;

public sealed class TextureLookup : IDisposable
{
	public readonly struct Entry(Rectangle region, string basePath)
	{
		public readonly Rectangle Region = region;
		public readonly string Small = $"{basePath}-s.png";
		public readonly string Medium = $"{basePath}.png";
		public readonly string Large = $"{basePath}-l.png";
	}

	private readonly Image<Rgba32> _sourceImage;
	private readonly Dictionary<string, Entry> _entryMap;
	private readonly ConcurrentDictionary<string, Task<string>> _files = new();

	public TextureLookup(Image<Rgba32> sourceImage, Dictionary<string, Entry> entryMap)
	{
		_sourceImage = sourceImage;
		_entryMap = entryMap;
	}

	public void Dispose()
	{
		_sourceImage.Dispose();
	}

	public async Task<string?> LoadAsync(string name, TextureScale scale)
	{
		if (!_entryMap.TryGetValue(name, out var entry))
		{
			return default;
		}

		var filePath = scale switch
		{
			TextureScale.S => entry.Small,
			TextureScale.M => entry.Medium,
			TextureScale.L => entry.Large,
			_ => entry.Medium,
		};

		if (_files.TryGetValue(filePath, out var fileTask))
		{
			return await fileTask;
		}

		var task = GenerateFileAsync(filePath, entry.Region, scale);
		_files[filePath] = task;
		return await task;
	}

	private async Task<string> GenerateFileAsync(string filePath, Rectangle region, TextureScale textureScale)
	{
		var croppedImage = _sourceImage.Clone(ctx => ctx.Crop(region));
		var scale = textureScale switch
		{
			TextureScale.S => 3,
			TextureScale.M => 6,
			TextureScale.L => 12,
			_ => 1
		};
		croppedImage.Mutate(ctx => ctx.Resize(ctx.GetCurrentSize().Width * scale, ctx.GetCurrentSize().Height * scale, KnownResamplers.NearestNeighbor));
		await croppedImage.SaveAsPngAsync(filePath);
		return filePath;
	}
}
