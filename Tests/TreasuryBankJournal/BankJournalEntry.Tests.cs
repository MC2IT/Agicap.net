namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BankJournalEntry"/> class.
/// </summary>
[TestClass]
public sealed class BankJournalEntryTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/BankJournalEntry.json"));
		var bankJournalEntry = JsonSerializer.Deserialize<BankJournalEntry>(json, JsonSerializerOptions.Web)!;

		IsNull(bankJournalEntry.AccountingAccountExternalId);
		AreEqual("201.01000", bankJournalEntry.AccountingAccountNumber);
		AreEqual("USD", bankJournalEntry.AccountingCurrency);
		AreEqual(new Guid("f7f7ed5c-943c-4385-aa8d-145fd76b2fa1"), bankJournalEntry.AgicapUniqueId);
		AreEqual("Cars bank account", bankJournalEntry.BankAccountName);
		AreEqual("RIBA", bankJournalEntry.Causale);
		HasCount(2, bankJournalEntry.Counterparts);
		AreEqual(900_000, bankJournalEntry.CreditInAccountingCurrency);
		AreEqual(1_000_000, bankJournalEntry.CreditInOriginalCurrency);
		IsNull(bankJournalEntry.DebitInAccountingCurrency);
		IsNull(bankJournalEntry.DebitInOriginalCurrency);
		IsNull(bankJournalEntry.EntryMemo);
		IsNull(bankJournalEntry.ExchangeRate);
		AreEqual("0o00001l", bankJournalEntry.ExportEntryReference);
		AreEqual(1, bankJournalEntry.IndexInExport);
		AreEqual(57, bankJournalEntry.IndexInYear);
		AreEqual("SG1", bankJournalEntry.JournalCode);
		AreEqual("ACME Payment", bankJournalEntry.Name);
		AreEqual("EUR", bankJournalEntry.OriginalCurrency);
		AreEqual(new DateTime(2024, 12, 24), bankJournalEntry.PaymentDate);
		AreEqual(BankJournalEntryType.BANK, bankJournalEntry.Type);
	}
}
