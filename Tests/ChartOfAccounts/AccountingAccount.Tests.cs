namespace Mc2it.Agicap.ChartOfAccounts;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="AccountingAccount"/> class.
/// </summary>
[TestClass]
public class AccountingAccountTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/ChartOfAccounts/AccountingAccount.json"));
		var accountingAccount = JsonSerializer.Deserialize<AccountingAccount>(json, JsonSerializerOptions.Web)!;

		accountingAccount.AccountingAccountName.ShouldBe("MC2IT Development Department");
		accountingAccount.AccountingAccountNumber.ShouldBe("99999999");
		accountingAccount.AccountingAccountType.ShouldBe(AccountingAccountType.Other);
		accountingAccount.ExternalId.ShouldBeNull();
		accountingAccount.TaxKey.ShouldBeNull();
		accountingAccount.VatRate.ShouldBeNull();
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
		json.ShouldContain("\"accountingAccountName\":\"MC2IT Development Department\"");
		json.ShouldContain("\"accountingAccountNumber\":\"99999999\"");
		json.ShouldContain("\"accountingAccountType\":\"Supplier\"");
		json.ShouldContain("\"externalId\":\"123456\"");
		json.ShouldNotContain("\"taxKey\"");
		json.ShouldNotContain("\"vatRate\"");
	}
}
