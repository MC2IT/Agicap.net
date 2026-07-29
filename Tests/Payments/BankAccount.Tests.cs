namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="BankAccount"/> class.
/// </summary>
[TestClass]
public sealed class BankAccountTests {

	[TestMethod]
	public void IsEmpty() {
		IsTrue(new BankAccount().IsEmpty);
		IsTrue(new BankAccount { BankName = " ", Bic = " ", Identifier = " " }.IsEmpty);
	}

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/BankAccount.json"));
		var bankAccount = JsonSerializer.Deserialize<BankAccount>(json, JsonSerializerOptions.Web)!;
		AreEqual("My Bank", bankAccount.BankName);
		AreEqual("BNPAFRPPXXX", bankAccount.Bic);
		AreEqual("FR", bankAccount.Country);
		AreEqual("FR7630006000011234567890189", bankAccount.Identifier);
		IsNull(bankAccount.IntermediaryBankBic);
		IsNull(bankAccount.LocalClearingCode);
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
		Contains("\"bankName\":\"My Bank\"", json);
		Contains("\"identifier\":\"FR7630006000011234567890189\"", json);
		DoesNotContain("\"intermediaryBankBic\"", json);
		DoesNotContain("\"localClearingCode\"", json);
	}
}
