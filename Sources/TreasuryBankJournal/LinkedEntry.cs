namespace Mc2it.Agicap.TreasuryBankJournal;

/// <summary>
///	Represents a reference to a previously exported journal entry linked to a counterpart.
/// </summary>
public class LinkedEntry {

	/// <summary>
	/// The unique identifier of the linked entry.
	/// </summary>
	public Guid AgicapUniqueId { get; set; } = Guid.Empty;

	/// <summary>
	/// The unique export reference of the linked entry.
	/// </summary>
	public string ExportEntryReference { get; set; } = "";
}
