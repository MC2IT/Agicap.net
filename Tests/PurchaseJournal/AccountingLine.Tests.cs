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
		AreEqual("EUR", accountingLine.AccountingCurrency);
		AreEqual("6263", accountingLine.AccountNumber);
		AreEqual(AccountingLineAccountType.ExpenseAccount, accountingLine.AccountType);
		IsEmpty(accountingLine.AdditionalAnalyticalCodes);
		AreSequenceEqual(new Dictionary<string, string>() { ["BusinessScope"] = "R&D", ["PurchaseType"] = "Cloud servers" }, accountingLine.AnalyticalCodes);
		AreEqual(0.8, accountingLine.ConversionRate);
		AreEqual(0, accountingLine.ConvertedCreditAmount);
		AreEqual(80, accountingLine.ConvertedDebitAmount);
		AreEqual(0, accountingLine.Credit);
		AreEqual("USD", accountingLine.Currency);
		AreEqual(100, accountingLine.Debit);
		AreEqual(new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), accountingLine.LineItemId);
		IsNull(accountingLine.TaxKey);
		IsNull(accountingLine.ThirdPartyAccount);
		AreEqual("G", accountingLine.Type);
		AreEqual("VAT 20%", accountingLine.VatAccountName);
	}
}
