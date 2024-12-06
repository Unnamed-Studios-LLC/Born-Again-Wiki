using BornAgainWiki.Providers;
using Lifti;
using Lifti.Querying;
using System.Collections.Concurrent;

namespace BornAgainWiki.Search;

public sealed class SearchEngine : IDisposable
{
	private readonly FullTextIndex<string> _titleIndex;
	private readonly FullTextIndex<string> _pageIndex;
	private readonly ConcurrentDictionary<string, SearchPage> _pages = new();
	private readonly SemaphoreSlim _batchAccess = new(1, 1);
	private readonly IServiceProvider _serviceProvider;

	public SearchEngine(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;

		_titleIndex = new FullTextIndexBuilder<string>()
			.WithObjectTokenization<SearchPage>(options => options
				.WithKey(b => b.PageKey)
				.WithField("Title", b => b.Title, tokenOptions => tokenOptions.CaseInsensitive()))
			.WithSimpleQueryParser(o => o
				.AssumeFuzzySearchTerms()
				.WithFuzzySearchDefaults(len => (ushort)(4 + len / 2), len => (ushort)Math.Max(1, 4 + len / 4)))
			.Build();
		_pageIndex = new FullTextIndexBuilder<string>()
			.WithObjectTokenization<SearchPage>(options => options
				.WithKey(b => b.PageKey)
				.WithField("Title", b => b.Title, tokenOptions => tokenOptions.CaseInsensitive())
				.WithField("Description", b => b.Description, tokenOptions => tokenOptions.CaseInsensitive()))
			.WithSimpleQueryParser(o => o
				.AssumeFuzzySearchTerms()
				.WithFuzzySearchDefaults(len => (ushort)(len / 2), len => (ushort)Math.Max(1, 1 + len / 4)))
			.Build();
	}

	public async Task AddPageAsync(SearchPage page)
	{
		await _titleIndex.AddAsync(page);
		await _pageIndex.AddAsync(page);
		_pages[page.PageKey] = page;
	}

	public async Task AddPagesAsync(IEnumerable<SearchPage> pages)
	{
		await _titleIndex.AddRangeAsync(pages);
		await _pageIndex.AddRangeAsync(pages);
		foreach (var page in pages)
		{
			_pages[page.PageKey] = page;
		}
	}

	public async Task CommitBatchAsync()
	{
		await _titleIndex.CommitBatchChangeAsync();
		await _pageIndex.CommitBatchChangeAsync();
		_batchAccess.Release();
	}

	public void Dispose()
	{
		_titleIndex.Dispose();
		_pageIndex.Dispose();
	}

	public async Task RemovePageAsync(string pageKey)
	{
		await _titleIndex.RemoveAsync(pageKey);
		await _pageIndex.RemoveAsync(pageKey);
		_pages.Remove(pageKey, out _);
	}

	public async Task RemovePageAsync(SearchPage page)
	{
		await _titleIndex.RemoveAsync(page.PageKey);
		await _pageIndex.RemoveAsync(page.PageKey);
		_pages.Remove(page.PageKey, out _);
	}

	public async Task<List<SearchPage>> SearchPageAsync(string searchQuery)
	{
		await InitAsync();
		var pages = new List<SearchPage>();
		var results = _pageIndex.Search(searchQuery);
		foreach (var result in results)
		{
			if (!_pages.TryGetValue(result.Key, out var page)) continue;
			pages.Add(page);
		}
		return pages;
	}

	public async Task<List<SearchPage>> SearchTitleAsync(string searchQuery)
	{
		await InitAsync();
		var pages = new List<SearchPage>();
		var results = _titleIndex.Search(searchQuery);
		foreach (var result in results)
		{
			if (!_pages.TryGetValue(result.Key, out var page)) continue;
			pages.Add(page);
		}
		return pages;
	}

	public async Task StartBatchAsync()
	{
		await _batchAccess.WaitAsync();
		_titleIndex.BeginBatchChange();
		_pageIndex.BeginBatchChange();
	}

	private async Task InitAsync()
	{
		var objectLibraryProvider = _serviceProvider.GetRequiredService<ObjectLibraryProvider>();
		await objectLibraryProvider.GetAsync();
	}
}
