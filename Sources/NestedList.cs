namespace Mc2it.Agicap;

/// <summary>
/// Represents a strongly typed list of objects.
/// </summary>
/// <typeparam name="T">The type of items in the list.</typeparam>
public sealed class NestedList<T> {

	/// <summary>
	/// The list items.
	/// </summary>
	public IList<T> Items { get; init; } = [];
}
