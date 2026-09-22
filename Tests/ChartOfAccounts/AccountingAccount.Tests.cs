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

		Assert.AreEqual("MC2IT Development Department", accountingAccount.AccountingAccountName);
		Assert.AreEqual("99999999", accountingAccount.AccountingAccountNumber);
		Assert.AreEqual(AccountingAccountType.Other, accountingAccount.AccountingAccountType);
		Assert.IsNull(accountingAccount.ExternalId);
		Assert.IsNull(accountingAccount.TaxKey);
		Assert.IsNull(accountingAccount.VatRate);
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
		Assert.Contains("\"accountingAccountName\":\"MC2IT Development Department\"", json);
		Assert.Contains("\"accountingAccountNumber\":\"99999999\"", json);
		Assert.Contains("\"accountingAccountType\":\"Supplier\"", json);
		Assert.Contains("\"externalId\":\"123456\"", json);
		Assert.DoesNotContain("\"taxKey\"", json);
		Assert.DoesNotContain("\"vatRate\"", json);
	}
}
