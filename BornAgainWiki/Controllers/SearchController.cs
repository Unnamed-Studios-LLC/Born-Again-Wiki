using BornAgainWiki.Models.Search;
using BornAgainWiki.Search;
using Microsoft.AspNetCore.Mvc;

namespace BornAgainWiki.Controllers;

public class SearchController : Controller
{
	private readonly SearchEngine _searchEngine;

	public SearchController(SearchEngine searchEngine)
	{
		_searchEngine = searchEngine;
	}

	public async Task<IActionResult> Index([FromQuery(Name = "s")] string search)
	{
		if (string.IsNullOrEmpty(search)) return View(new SearchViewModel(string.Empty, []));
		var results = await _searchEngine.SearchPageAsync(search);
		return View(new SearchViewModel(search, results.Take(20).ToList()));
	}

	public async Task<IActionResult> Results([FromQuery(Name = "s")] string search)
	{
		if (string.IsNullOrEmpty(search)) return BadRequest();
		var results = await _searchEngine.SearchTitleAsync(search);
		return Ok(results.Take(10));
	}
}
