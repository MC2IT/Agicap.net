namespace Mc2it.Agicap.ChartOfAccounts;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="AccountingAccount"/> class.
/// </summary>
[TestClass]
public sealed class AccountingAccountTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/ChartOfAccounts/AccountingAccount.json"));
		var accountingAccount = JsonSerializer.Deserialize<AccountingAccount>(json, JsonSerializerOptions.Web)!;
		AreEqual("MC2IT Development Department", accountingAccount.AccountingAccountName);
		AreEqual("99999999", accountingAccount.AccountingAccountNumber);
		AreEqual(AccountingAccountType.Other, accountingAccount.AccountingAccountType);
		IsNull(accountingAccount.ExternalId);
		IsNull(accountingAccount.TaxKey);
		IsNull(accountingAccount.VatRate);
	}

	[TestMethod]
	public void ToJson() {
		var accountingAccount = new AccountingAccount {
			AccountingAccountName = "MC2IT Development Department",
			AccountingAccountNumber = "99999999",
			AccountingAccountType = AccountingAccountType.Supplier,
			ExternalId = "123456"
		};

		var json = JsonSerializer.Serialize(accountingAccount, JsonSerializerOptions.Web);
		Contains("\"accountingAccountName\":\"MC2IT Development Department\"", json);
		Contains("\"accountingAccountNumber\":\"99999999\"", json);
		Contains("\"accountingAccountType\":\"Supplier\"", json);
		Contains("\"externalId\":\"123456\"", json);
		DoesNotContain("\"taxKey\"", json);
		DoesNotContain("\"vatRate\"", json);
	}
}
