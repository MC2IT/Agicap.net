namespace Mc2it.Agicap;

/// <summary>
/// Identifies a journal entry that was imported in the client accounting system.
/// </summary>
public class ImportedEntry {

	/// <summary>
	/// A unique identifier from Agicap.
	/// </summary>
	public Guid EntryAgicapUniqueId { get; set; }
}
