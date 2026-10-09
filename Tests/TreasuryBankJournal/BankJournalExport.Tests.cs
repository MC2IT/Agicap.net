namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BankJournalExport"/> class.
/// </summary>
[TestClass]
public class BankJournalExportTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/BankJournalExport.json"));
		var bankJournalExport = JsonSerializer.Deserialize<BankJournalExport>(json, JsonSerializerOptions.Web)!;

		bankJournalExport.BankJournalExportIndexInYear.ShouldBe(1);
		bankJournalExport.EntityName.ShouldBe("Contoso");
		bankJournalExport.Entries.Count.ShouldBe(1);
		bankJournalExport.ExportId.ShouldBe(new Guid("7397d1b5-d76d-43d2-a153-2bcff5e57455"));
		bankJournalExport.Year.ShouldBe(2024);
	}
}

/// <summary>
/// Tests the features of the <see cref="BankJournalExportCounts"/> class.
/// </summary>
[TestClass]
public class BankJournalExportCountsTests {

	[TestMethod]
	public void ToJson() {
		var exportCounts = new BankJournalExportCounts {
			CurrentBankJournalEntriesCountInYear = 666,
			CurrentBankJournalsCountInYear = 123
		};

		var json = JsonSerializer.Serialize(exportCounts, JsonSerializerOptions.Web);
		json.ShouldContain("\"currentBankJournalEntriesCountInYear\":666");
		json.ShouldContain("\"currentBankJournalsCountInYear\":123");
	}
}

/// <summary>
/// Tests the features of the <see cref="BankJournalExportSummary"/> class.
/// </summary>
[TestClass]
public class BankJournalExportSummaryTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/BankJournalExportSummary.json"));
		var exportSummary = JsonSerializer.Deserialize<BankJournalExportSummary>(json, JsonSerializerOptions.Web)!;

		exportSummary.ExportDateUtc.ShouldBe(new DateTime(2026, 6, 25, 8, 14, 52, DateTimeKind.Utc));
		exportSummary.ExportId.ShouldNotBe(Guid.Empty);
		exportSummary.ExportIndexInYear.ShouldBe(1);
		exportSummary.ExportYear.ShouldBe(2026);
		exportSummary.IndexInYearOfFirstEntryInBankJournal.ShouldBe(1);
		exportSummary.IndexInYearOfLastEntryInBankJournal.ShouldBe(5);
		exportSummary.NumberOfEntries.ShouldBe(5);
	}
}
