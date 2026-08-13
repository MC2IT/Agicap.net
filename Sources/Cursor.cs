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
