namespace Mc2it.Agicap.Suppliers;

/// <summary>
/// Represents a strongly typed list of objects, with a cursor allowing access to the next page of results.
/// </summary>
/// <typeparam name="T">The type of items in the list.</typeparam>
public class CursorPaginatedList<T> {

	/// <summary>
	/// The list items.
	/// </summary>
	public IList<T> Items { get; set; } = [];

	/// <summary>
	/// A cursor to pass back to fetch the next page, or <see langword="null"/> when the last page is reached.
	/// </summary>
	public string? NextCursor { get; set; }
}
