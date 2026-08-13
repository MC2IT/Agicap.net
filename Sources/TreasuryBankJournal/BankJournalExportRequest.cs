namespace Mc2it.Agicap.TreasuryBankJournal;

/// <summary>
/// Optional export parameters allowing to set where to start.
/// </summary>
public class BankJournalExportRequest {

	/// <summary>
	/// The number of bank journal entries previously created (starts at 1).
	/// </summary>
	public int CurrentBankJournalEntriesCountInYear { get; set => field = Math.Max(1, value); } = 1;

	/// <summary>
	/// The number of bank journal previously created (starts at 1).
	/// </summary>
	public int CurrentBankJournalsCountInYear { get; set => field = Math.Max(1, value); } = 1;
}
