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

		Assert.IsNull(bankJournalEntry.AccountingAccountExternalId);
		Assert.AreEqual("201.01000", bankJournalEntry.AccountingAccountNumber);
		Assert.AreEqual("USD", bankJournalEntry.AccountingCurrency);
		Assert.AreEqual(new Guid("f7f7ed5c-943c-4385-aa8d-145fd76b2fa1"), bankJournalEntry.AgicapUniqueId);
		Assert.AreEqual("Cars bank account", bankJournalEntry.BankAccountName);
		Assert.AreEqual("RIBA", bankJournalEntry.Causale);
		Assert.HasCount(2, bankJournalEntry.Counterparts);
		Assert.AreEqual(900_000, bankJournalEntry.CreditInAccountingCurrency);
		Assert.AreEqual(1_000_000, bankJournalEntry.CreditInOriginalCurrency);
		Assert.IsNull(bankJournalEntry.DebitInAccountingCurrency);
		Assert.IsNull(bankJournalEntry.DebitInOriginalCurrency);
		Assert.IsNull(bankJournalEntry.EntryMemo);
		Assert.IsNull(bankJournalEntry.ExchangeRate);
		Assert.AreEqual("0o00001l", bankJournalEntry.ExportEntryReference);
		Assert.AreEqual(1, bankJournalEntry.IndexInExport);
		Assert.AreEqual(57, bankJournalEntry.IndexInYear);
		Assert.AreEqual("SG1", bankJournalEntry.JournalCode);
		Assert.AreEqual("ACME Payment", bankJournalEntry.Name);
		Assert.AreEqual("EUR", bankJournalEntry.OriginalCurrency);
		Assert.AreEqual(new DateTime(2024, 12, 24), bankJournalEntry.PaymentDate);
		Assert.AreEqual(BankJournalEntryType.BANK, bankJournalEntry.Type);
	}
}
