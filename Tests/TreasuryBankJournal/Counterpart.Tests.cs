namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Counterpart"/> class.
/// </summary>
[TestClass]
public sealed class CounterpartTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/Counterpart.json"));
		var counterpart = JsonSerializer.Deserialize<Counterpart>(json, JsonSerializerOptions.Web)!;

		Assert.IsNull(counterpart.AccountingAccountExternalId);
		Assert.AreEqual("140.0000", counterpart.AccountingAccountNumber);
		Assert.AreEqual(CounterpartAccountingAccountType.SUPPLIER, counterpart.AccountingAccountType);
		Assert.AreEqual("USD", counterpart.AccountingCurrency);
		Assert.AreSequenceEqual(new Dictionary<string, string>() { ["Country"] = "FR", ["Project"] = "Marketing" }, counterpart.AnalyticalCodes);
		Assert.IsNull(counterpart.CreditInAccountingCurrency);
		Assert.IsNull(counterpart.CreditInOriginalCurrency);
		Assert.HasCount(2, counterpart.CustomFields ?? []);
		Assert.AreEqual(200_000, counterpart.DebitInAccountingCurrency);
		Assert.AreEqual(300_000, counterpart.DebitInOriginalCurrency);
		Assert.IsNotNull(counterpart.Document);
		Assert.IsNull(counterpart.ExchangeRate);
		Assert.AreEqual("SG1", counterpart.JournalCode);
		Assert.IsNull(counterpart.LinkedExportedEntry);
		Assert.AreEqual("ACME Invoice 2", counterpart.Name);
		Assert.AreEqual("EUR", counterpart.OriginalCurrency);
		Assert.IsNull(counterpart.TaxKey);
		Assert.AreEqual("S23", counterpart.ThirdPartyCode);
		Assert.IsNull(counterpart.ThirdPartyExternalId);
		Assert.AreEqual("Supplier 23", counterpart.ThirdPartyName);
	}
}
