namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Counterpart"/> class.
/// </summary>
[TestClass]
public class CounterpartTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/Counterpart.json"));
		var counterpart = JsonSerializer.Deserialize<Counterpart>(json, JsonSerializerOptions.Web)!;

		counterpart.AccountingAccountExternalId.ShouldBeNull();
		counterpart.AccountingAccountNumber.ShouldBe("140.0000");
		counterpart.AccountingAccountType.ShouldBe(CounterpartAccountingAccountType.SUPPLIER);
		counterpart.AccountingCurrency.ShouldBe("USD");
		counterpart.AnalyticalCodes.ShouldBe(new Dictionary<string, string>() { ["Country"] = "FR", ["Project"] = "Marketing" });
		counterpart.CreditInAccountingCurrency.ShouldBeNull();
		counterpart.CreditInOriginalCurrency.ShouldBeNull();
		(counterpart.CustomFields ?? []).Count.ShouldBe(2);
		counterpart.DebitInAccountingCurrency.ShouldBe(200_000);
		counterpart.DebitInOriginalCurrency.ShouldBe(300_000);
		counterpart.Document.ShouldNotBeNull();
		counterpart.ExchangeRate.ShouldBeNull();
		counterpart.JournalCode.ShouldBe("SG1");
		counterpart.LinkedExportedEntry.ShouldBeNull();
		counterpart.Name.ShouldBe("ACME Invoice 2");
		counterpart.OriginalCurrency.ShouldBe("EUR");
		counterpart.TaxKey.ShouldBeNull();
		counterpart.ThirdPartyCode.ShouldBe("S23");
		counterpart.ThirdPartyExternalId.ShouldBeNull();
		counterpart.ThirdPartyName.ShouldBe("Supplier 23");
	}
}
