using BornAgainWiki.Search;
using Microsoft.AspNetCore.Mvc;

namespace BornAgainWiki.Models.Search
{
	public sealed class SearchViewModel
	{
		public string Query { get; }
		public List<SearchPage> Pages { get; }

		public SearchViewModel(string query, List<SearchPage> pages)
		{
			Query = query;
			Pages = pages;
		}
	}
}
