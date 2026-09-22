namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BankAccount"/> class.
/// </summary>
[TestClass]
public sealed class BankAccountTests {

	[TestMethod]
	public void IsEmpty() {
		Assert.IsTrue(new BankAccount().IsEmpty);
		Assert.IsTrue(new BankAccount { BankName = " ", Bic = " ", Identifier = " " }.IsEmpty);
	}

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/BankAccount.json"));
		var bankAccount = JsonSerializer.Deserialize<BankAccount>(json, JsonSerializerOptions.Web)!;

		Assert.AreEqual("My Bank", bankAccount.BankName);
		Assert.AreEqual("BNPAFRPPXXX", bankAccount.Bic);
		Assert.AreEqual("FR", bankAccount.Country);
		Assert.AreEqual("FR7630006000011234567890189", bankAccount.Identifier);
		Assert.IsNull(bankAccount.IntermediaryBankBic);
		Assert.IsNull(bankAccount.LocalClearingCode);
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
		Assert.Contains("\"bankName\":\"My Bank\"", json);
		Assert.Contains("\"identifier\":\"FR7630006000011234567890189\"", json);
		Assert.DoesNotContain("\"intermediaryBankBic\"", json);
		Assert.DoesNotContain("\"localClearingCode\"", json);
	}
}
