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
	public async Task<IActionResult> Texture(string name)
	{
		var lookup = await _textureProvider.GetLookupAsync();
		if (lookup == null)
		{
			return StatusCode(500);
		}

		if (!lookup.TryGet(name, out var filePath) ||
			filePath == null)
		{
			return NotFound();
		}

		return PhysicalFile(filePath, "image/png");
	}
}
