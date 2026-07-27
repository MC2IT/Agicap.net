namespace Mc2it.Agicap;

/// <summary>
/// Represents information relevant to the pagination of data items.
/// </summary>
public sealed class Pagination {

	/// <summary>
	/// The number of items of the current page.
	/// </summary>
	public int CurrentPageItemsCount { get; init => field = Math.Max(0, value); }

	/// <summary>
	/// The number of the current page.
	/// </summary>
	public int CurrentPageNumber { get; init => field = Math.Max(1, value); } = 1;

	/// <summary>
	/// Value indicating whether a next page exists.
	/// </summary>
	public bool HasNextPage => CurrentPageNumber < PagesCount;

	/// <summary>
	/// Value indicating whether a previous page exists.
	/// </summary>
	public bool HasPreviousPage => CurrentPageNumber > 1;

	/// <summary>
	/// The total number of pages.
	/// </summary>
	public int PagesCount { get; init => field = Math.Max(0, value); }

	/// <summary>
	/// The number of items per page.
	/// </summary>
	public int PageSize { get; init => field = Math.Max(1, value); } = 100;

	/// <summary>
	/// The total number of items.
	/// </summary>
	public int TotalItemsCount { get; init => field = Math.Max(0, value); }
}
