namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BankJournalExportCounts"/> class.
/// </summary>
[TestClass]
public sealed class BankJournalExportCountsTests {

	[TestMethod]
	public void ToJson() {
		var exportRequest = new BankJournalExportCounts {
			CurrentBankJournalEntriesCountInYear = 666,
			CurrentBankJournalsCountInYear = 123
		};

		var json = JsonSerializer.Serialize(exportRequest, JsonSerializerOptions.Web);
		Contains("\"currentBankJournalEntriesCountInYear\":666", json);
		Contains("\"currentBankJournalsCountInYear\":123", json);
	}
}
