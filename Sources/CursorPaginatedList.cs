namespace Mc2it.Agicap;

/// <summary>
/// The cursor current state as returned after a query.
/// </summary>
public class Cursor {

	/// <summary>
	/// The export date in UTC of the newest returned bank journal export.
	/// </summary>
	public DateTime? After { get; set; }

	/// <summary>
	/// The export date in UTC of the oldest returned bank journal export.
	/// </summary>
	public DateTime? Before { get; set; }

	/// <summary>
	/// The number of exported bank journals returned.
	/// </summary>
	public int Size { get; set; }
}

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
