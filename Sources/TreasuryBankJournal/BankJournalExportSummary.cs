namespace Mc2it.Agicap.TreasuryBankJournal;

/// <summary>
/// A bank journal export description.
/// </summary>
public class BankJournalExportSummary {

	/// <summary>
	/// The export date.
	/// </summary>
	public DateTime ExportDateUtc { get; set; }

	/// <summary>
	/// The unique ID of the export.
	/// </summary>
	public Guid ExportId { get; set; }

	/// <summary>
	/// The index of the bank journal export in the <see cref="ExportYear"/> (starts at 1).
	/// </summary>
	public int ExportIndexInYear { get; set; }

	/// <summary>
	/// The year the export was done.
	/// </summary>
	public int ExportYear { get; set; }

	/// <summary>
	/// The index in <see cref="ExportYear"/> of the first entry in the bank journal export (starts at 1).
	/// </summary>
	public int IndexInYearOfFirstEntryInBankJournal { get; set; }

	/// <summary>
	/// The index in <see cref="ExportYear"/> of the last entry in the bank journal export (starts at 1).
	/// </summary>
	public int IndexInYearOfLastEntryInBankJournal { get; set; }

	/// <summary>
	/// The number of entries in the bank journal export.
	/// </summary>
	public int NumberOfEntries { get; set; }
}
