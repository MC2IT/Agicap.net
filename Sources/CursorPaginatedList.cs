namespace Mc2it.Agicap;

/// <summary>
/// Represents a strongly typed list of objects, with a cursor allowing access to the next/previous page of results.
/// </summary>
/// <typeparam name="T">The type of items in the list.</typeparam>
public class CursorPaginatedList<T> {

	/// <summary>
	/// The cursor current state as returned after a query.
	/// </summary>
	public Cursor Cursor { get; set; } = new();

	/// <summary>
	/// The list items.
	/// </summary>
	public IList<T> Items { get; set; } = [];
}
