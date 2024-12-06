namespace BornAgainWiki.Search;

public class SearchPage(string pageKey, string title, string description, string? image)
{
	public string PageKey { get; } = pageKey;
	public string Title { get; } = title;
	public string Description { get; } = description;
	public string? Image { get; } = image;
}
