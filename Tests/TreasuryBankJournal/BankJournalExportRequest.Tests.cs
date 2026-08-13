namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BankJournalExportRequest"/> class.
/// </summary>
[TestClass]
public sealed class BankJournalExportRequestTests {

	[TestMethod]
	public void ToJson() {
		var exportRequest = new BankJournalExportRequest {
			CurrentBankJournalEntriesCountInYear = 666,
			CurrentBankJournalsCountInYear = 123
		};

		var json = JsonSerializer.Serialize(exportRequest, JsonSerializerOptions.Web);
		Contains("\"currentBankJournalEntriesCountInYear\":666", json);
		Contains("\"currentBankJournalsCountInYear\":123", json);
	}
}
