namespace Mc2it.Agicap;

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
