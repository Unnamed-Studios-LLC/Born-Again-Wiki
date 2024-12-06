using BornAgainWiki.Enums;
using BornAgainWiki.Providers;
using Microsoft.AspNetCore.Mvc;

namespace BornAgainWiki.Controllers;

[Route("tex")]
public class TextureController : Controller
{
	private readonly TextureProvider _textureProvider;

	public TextureController(TextureProvider textureProvider)
	{
		_textureProvider = textureProvider;
	}

	[HttpGet("{name}")]
	public async Task<IActionResult> Texture(string name, [FromQuery(Name = "s")] TextureScale scale = TextureScale.M)
	{
		var lookup = await _textureProvider.GetLookupAsync();
		if (lookup == null)
		{
			return StatusCode(500);
		}

		var filePath =await lookup.LoadAsync(name, scale);
		if (string.IsNullOrWhiteSpace(filePath))
		{
			return NotFound();
		}

		return PhysicalFile(filePath, "image/png");
	}
}
