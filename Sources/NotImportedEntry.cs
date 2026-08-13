namespace Mc2it.Agicap;

/// <summary>
/// Identifies a journal entry that was not imported in the client accounting system.
/// </summary>
public class NotImportedEntry: ImportedEntry {

	/// <summary>
	/// The errors preventing the journal entry from being imported.
	/// </summary>
	public IList<NotImportedEntryError> Errors { get; set; } = [];
}
