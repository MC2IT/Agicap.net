namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BankJournalEntry"/> class.
/// </summary>
[TestClass]
public class BankJournalEntryTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/BankJournalEntry.json"));
		var bankJournalEntry = JsonSerializer.Deserialize<BankJournalEntry>(json, JsonSerializerOptions.Web)!;

		bankJournalEntry.AccountingAccountExternalId.ShouldBeNull();
		bankJournalEntry.AccountingAccountNumber.ShouldBe("201.01000");
		bankJournalEntry.AccountingCurrency.ShouldBe("USD");
		bankJournalEntry.AgicapUniqueId.ShouldBe(new Guid("f7f7ed5c-943c-4385-aa8d-145fd76b2fa1"));
		bankJournalEntry.BankAccountName.ShouldBe("Cars bank account");
		bankJournalEntry.Causale.ShouldBe("RIBA");
		bankJournalEntry.Counterparts.Count.ShouldBe(2);
		bankJournalEntry.CreditInAccountingCurrency.ShouldBe(900_000);
		bankJournalEntry.CreditInOriginalCurrency.ShouldBe(1_000_000);
		bankJournalEntry.DebitInAccountingCurrency.ShouldBeNull();
		bankJournalEntry.DebitInOriginalCurrency.ShouldBeNull();
		bankJournalEntry.EntryMemo.ShouldBeNull();
		bankJournalEntry.ExchangeRate.ShouldBeNull();
		bankJournalEntry.ExportEntryReference.ShouldBe("0o00001l");
		bankJournalEntry.IndexInExport.ShouldBe(1);
		bankJournalEntry.IndexInYear.ShouldBe(57);
		bankJournalEntry.JournalCode.ShouldBe("SG1");
		bankJournalEntry.Name.ShouldBe("ACME Payment");
		bankJournalEntry.OriginalCurrency.ShouldBe("EUR");
		bankJournalEntry.PaymentDate.ShouldBe(new DateTime(2024, 12, 24));
		bankJournalEntry.Type.ShouldBe(BankJournalEntryType.BANK);
	}
}
