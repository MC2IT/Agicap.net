namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BankJournalExport"/> class.
/// </summary>
[TestClass]
public sealed class BankJournalExportTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/BankJournalExport.json"));
		var bankJournalExport = JsonSerializer.Deserialize<BankJournalExport>(json, JsonSerializerOptions.Web)!;

		AreEqual(1, bankJournalExport.BankJournalExportIndexInYear);
		AreEqual("Contoso", bankJournalExport.EntityName);
		HasCount(1, bankJournalExport.Entries);
		AreEqual(new Guid("7397d1b5-d76d-43d2-a153-2bcff5e57455"), bankJournalExport.ExportId);
		AreEqual(2024, bankJournalExport.Year);
	}
}

/// <summary>
/// Tests the features of the <see cref="BankJournalExportCounts"/> class.
/// </summary>
[TestClass]
public sealed class BankJournalExportCountsTests {

	[TestMethod]
	public void ToJson() {
		var exportCounts = new BankJournalExportCounts {
			CurrentBankJournalEntriesCountInYear = 666,
			CurrentBankJournalsCountInYear = 123
		};

		var json = JsonSerializer.Serialize(exportCounts, JsonSerializerOptions.Web);
		Contains("\"currentBankJournalEntriesCountInYear\":666", json);
		Contains("\"currentBankJournalsCountInYear\":123", json);
	}
}

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
