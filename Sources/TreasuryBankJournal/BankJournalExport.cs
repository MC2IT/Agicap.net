namespace Mc2it.Agicap.TreasuryBankJournal;

/// <summary>
/// Represents an export of the bank journal.
/// </summary>
public class BankJournalExport {

	/// <summary>
	/// The index of the bank journal export in the current year.
	/// </summary>
	public int BankJournalExportIndexInYear { get; set; }

	/// <summary>
	/// The entity name.
	/// </summary>
	public string EntityName { get; set; } = "";

	/// <summary>
	/// The entries in the bank journal export.
	/// </summary>
	public IList<BankJournalEntry> Entries { get; set; } = [];

	/// <summary>
	/// The identifier of the export as specified in the request.
	/// </summary>
	public Guid ExportId { get; set; }

	/// <summary>
	/// The current year when the bank journal has been exported.
	/// </summary>
	public int Year { get; set; }
}
