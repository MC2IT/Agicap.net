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
