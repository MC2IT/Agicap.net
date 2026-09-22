namespace Mc2it.Agicap.PurchaseJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="AccountingLine"/> class.
/// </summary>
[TestClass]
public sealed class AccountingLineTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/PurchaseJournal/AccountingLine.json"));
		var accountingLine = JsonSerializer.Deserialize<AccountingLine>(json, JsonSerializerOptions.Web)!;

		Assert.AreEqual("EUR", accountingLine.AccountingCurrency);
		Assert.AreEqual("6263", accountingLine.AccountNumber);
		Assert.AreEqual(AccountingLineAccountType.ExpenseAccount, accountingLine.AccountType);
		Assert.IsEmpty(accountingLine.AdditionalAnalyticalCodes);
		Assert.AreSequenceEqual(new Dictionary<string, string>() { ["BusinessScope"] = "R&D", ["PurchaseType"] = "Cloud servers" }, accountingLine.AnalyticalCodes);
		Assert.AreEqual(0.8, accountingLine.ConversionRate);
		Assert.AreEqual(0, accountingLine.ConvertedCreditAmount);
		Assert.AreEqual(80, accountingLine.ConvertedDebitAmount);
		Assert.AreEqual(0, accountingLine.Credit);
		Assert.AreEqual("USD", accountingLine.Currency);
		Assert.AreEqual(100, accountingLine.Debit);
		Assert.AreEqual(new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), accountingLine.LineItemId);
		Assert.IsNull(accountingLine.TaxKey);
		Assert.IsNull(accountingLine.ThirdPartyAccount);
		Assert.AreEqual("G", accountingLine.Type);
		Assert.AreEqual("VAT 20%", accountingLine.VatAccountName);
	}
}
