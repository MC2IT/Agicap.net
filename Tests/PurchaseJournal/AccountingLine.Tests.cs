namespace Mc2it.Agicap.PurchaseJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="AccountingLine"/> class.
/// </summary>
[TestClass]
public class AccountingLineTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/PurchaseJournal/AccountingLine.json"));
		var accountingLine = JsonSerializer.Deserialize<AccountingLine>(json, JsonSerializerOptions.Web)!;

		accountingLine.AccountingCurrency.ShouldBe("EUR");
		accountingLine.AccountNumber.ShouldBe("6263");
		accountingLine.AccountType.ShouldBe(AccountingLineAccountType.ExpenseAccount);
		accountingLine.AdditionalAnalyticalCodes.ShouldBeEmpty();
		accountingLine.AnalyticalCodes.ShouldBe(new Dictionary<string, string>() { ["BusinessScope"] = "R&D", ["PurchaseType"] = "Cloud servers" });
		accountingLine.ConversionRate.ShouldBe(0.8);
		accountingLine.ConvertedCreditAmount.ShouldBe(0);
		accountingLine.ConvertedDebitAmount.ShouldBe(80);
		accountingLine.Credit.ShouldBe(0);
		accountingLine.Currency.ShouldBe("USD");
		accountingLine.Debit.ShouldBe(100);
		accountingLine.LineItemId.ShouldBe(new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"));
		accountingLine.TaxKey.ShouldBeNull();
		accountingLine.ThirdPartyAccount.ShouldBeNull();
		accountingLine.Type.ShouldBe("G");
		accountingLine.VatAccountName.ShouldBe("VAT 20%");
	}
}
