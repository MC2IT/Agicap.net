namespace Mc2it.Agicap;

using System.Text.Json.Serialization;

/// <summary>
/// Represents information relevant to the pagination of data items.
/// </summary>
public class Pagination {

	/// <summary>
	/// The number of items of the current page.
	/// </summary>
	public int CurrentPageItemsCount { get; set => field = Math.Max(0, value); }

	/// <summary>
	/// The number of the current page.
	/// </summary>
	public int CurrentPageNumber { get; set => field = Math.Max(1, value); } = 1;

	/// <summary>
	/// Value indicating whether a next page exists.
	/// </summary>
	[JsonIgnore]
	public bool HasNextPage => CurrentPageNumber < PagesCount;

	/// <summary>
	/// Value indicating whether a previous page exists.
	/// </summary>
	[JsonIgnore]
	public bool HasPreviousPage => CurrentPageNumber > 1;

	/// <summary>
	/// The total number of pages.
	/// </summary>
	public int PagesCount { get; set => field = Math.Max(0, value); }

	/// <summary>
	/// The number of items per page.
	/// </summary>
	public int PageSize { get; set => field = Math.Max(1, value); } = 100;

	/// <summary>
	/// The total number of items.
	/// </summary>
	public int TotalItemsCount { get; set => field = Math.Max(0, value); }
}

/// <summary>
/// Represents a strongly typed list of objects, with information relevant to the pagination of its items.
/// </summary>
/// <typeparam name="T">The type of items in the list.</typeparam>
public class PaginatedList<T> {

	/// <summary>
	/// The list items.
	/// </summary>
	public IList<T> Items { get; set; } = [];

	/// <summary>
	/// The information relevant to the pagination of list items.
	/// </summary>
	public Pagination Pagination { get; set; } = new();
}
