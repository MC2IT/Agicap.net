namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BankJournalExportSummary"/> class.
/// </summary>
[TestClass]
public sealed class BankJournalExportSummaryTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/BankJournalExportSummary.json"));
		var exportSummary = JsonSerializer.Deserialize<BankJournalExportSummary>(json, JsonSerializerOptions.Web)!;

		AreEqual(new DateTime(2026, 6, 25, 8, 14, 52, DateTimeKind.Utc), exportSummary.ExportDateUtc);
		AreNotEqual(Guid.Empty, exportSummary.ExportId);
		AreEqual(1, exportSummary.ExportIndexInYear);
		AreEqual(2026, exportSummary.ExportYear);
		AreEqual(1, exportSummary.IndexInYearOfFirstEntryInBankJournal);
		AreEqual(5, exportSummary.IndexInYearOfLastEntryInBankJournal);
		AreEqual(5, exportSummary.NumberOfEntries);
	}
}
