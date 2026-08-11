namespace Mc2it.Agicap;

/// <summary>
/// Represents a purchase journal entry that was not imported in the client accounting system.
/// </summary>
public class NotImportedEntry {

	/// <summary>
	/// A unique identifier from Agicap.
	/// </summary>
	public Guid EntryAgicapUniqueId { get; set; }

	/// <summary>
	/// The rrrors preventing the journal entry from being imported.
	/// </summary>
	public IList<NotImportedEntryError> Errors { get; set; } = [];
}
