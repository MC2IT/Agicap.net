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

/// <summary>
/// Optional export parameters allowing to set where to start.
/// </summary>
public class BankJournalExportCounts {

	/// <summary>
	/// The number of bank journal entries previously created (starts at 1).
	/// </summary>
	public int CurrentBankJournalEntriesCountInYear { get; set => field = Math.Max(1, value); } = 1;

	/// <summary>
	/// The number of bank journal previously created (starts at 1).
	/// </summary>
	public int CurrentBankJournalsCountInYear { get; set => field = Math.Max(1, value); } = 1;
}

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
	public int ExportIndexInYear { get; set => field = Math.Max(1, value); } = 1;

	/// <summary>
	/// The year the export was done.
	/// </summary>
	public int ExportYear { get; set; }

	/// <summary>
	/// The index in <see cref="ExportYear"/> of the first entry in the bank journal export (starts at 1).
	/// </summary>
	public int IndexInYearOfFirstEntryInBankJournal { get; set => field = Math.Max(1, value); } = 1;

	/// <summary>
	/// The index in <see cref="ExportYear"/> of the last entry in the bank journal export (starts at 1).
	/// </summary>
	public int IndexInYearOfLastEntryInBankJournal { get; set => field = Math.Max(1, value); } = 1;

	/// <summary>
	/// The number of entries in the bank journal export.
	/// </summary>
	public int NumberOfEntries { get; set; }
}
