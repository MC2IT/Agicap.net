namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BankAccount"/> class.
/// </summary>
[TestClass]
public class BankAccountTests {

	[TestMethod]
	public void IsEmpty() {
		new BankAccount().IsEmpty.ShouldBeTrue();
		new BankAccount { BankName = " ", Bic = " ", Identifier = " " }.IsEmpty.ShouldBeTrue();
	}

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/BankAccount.json"));
		var bankAccount = JsonSerializer.Deserialize<BankAccount>(json, JsonSerializerOptions.Web)!;

		bankAccount.BankName.ShouldBe("My Bank");
		bankAccount.Bic.ShouldBe("BNPAFRPPXXX");
		bankAccount.Country.ShouldBe("FR");
		bankAccount.Identifier.ShouldBe("FR7630006000011234567890189");
		bankAccount.IntermediaryBankBic.ShouldBeNull();
		bankAccount.LocalClearingCode.ShouldBeNull();
	}

	[TestMethod]
	public void ToJson() {
		var bankAccount = new BankAccount {
			BankName = "My Bank",
			Bic = "BNPAFRPPXXX",
			Country = "FR",
			Identifier = "FR7630006000011234567890189"
		};

		var json = JsonSerializer.Serialize(bankAccount, JsonSerializerOptions.Web);
		json.ShouldContain("\"bankName\":\"My Bank\"");
		json.ShouldContain("\"identifier\":\"FR7630006000011234567890189\"");
		json.ShouldNotContain("\"intermediaryBankBic\"");
		json.ShouldNotContain("\"localClearingCode\"");
	}
}
