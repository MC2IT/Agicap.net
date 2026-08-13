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

		IsNull(counterpart.AccountingAccountExternalId);
		AreEqual("140.0000", counterpart.AccountingAccountNumber);
		AreEqual(CounterpartAccountingAccountType.SUPPLIER, counterpart.AccountingAccountType);
		AreEqual("USD", counterpart.AccountingCurrency);
		AreSequenceEqual(new Dictionary<string, string>() { ["Country"] = "FR", ["Project"] = "Marketing" }, counterpart.AnalyticalCodes);
		AreEqual(200_000, counterpart.DebitInAccountingCurrency);
		AreEqual(300_000, counterpart.DebitInOriginalCurrency);
		IsNotNull(counterpart.Document);
		IsNull(counterpart.ExchangeRate);
		AreEqual("SG1", counterpart.JournalCode);
		IsNull(counterpart.LinkedExportedEntry);
		AreEqual("ACME Invoice 2", counterpart.Name);
		AreEqual("EUR", counterpart.OriginalCurrency);
		IsNull(counterpart.TaxKey);
		AreEqual("S23", counterpart.ThirdPartyCode);
		IsNull(counterpart.ThirdPartyExternalId);
		AreEqual("Supplier 23", counterpart.ThirdPartyName);
	}
}
