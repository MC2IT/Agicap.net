namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="SynchronizedBeneficiary"/> class.
/// </summary>
[TestClass]
public sealed class SynchronizedBeneficiaryTests {

	[TestMethod]
	public void FromBeneficiary() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/Beneficiary.json"));
		var synchronizedBeneficiary = new SynchronizedBeneficiary("MC2IT-DEVELOPMENT", JsonSerializer.Deserialize<Beneficiary>(json, JsonSerializerOptions.Web)!);
		AreEqual("FR7630006000011234567890189", synchronizedBeneficiary.AccountNumber);
		AreEqual("FR", synchronizedBeneficiary.BankCountry);
		AreEqual("BNPAFRPPXXX", synchronizedBeneficiary.BankIdentifier);
		AreEqual("My Bank", synchronizedBeneficiary.BankName);
		IsNull(synchronizedBeneficiary.CompanyLegalId);
		AreEqual("MC2IT-DEVELOPMENT", synchronizedBeneficiary.ErpId);
		AreEqual("My Company", synchronizedBeneficiary.Name);
		AreEqual("FR", synchronizedBeneficiary.PostalAddress?.Country);
		IsNull(synchronizedBeneficiary.SupplierErpIds);
	}

	[TestMethod]
	public void ToJson() {
		var synchronizedBeneficiary = new SynchronizedBeneficiary {
			BankAccount = new() { BankName = "My Bank" },
			ErpId = "MC2IT-DEVELOPMENT",
			Name = "My Company",
			PostalAddress = new(),
			SupplierErpIds = ["FOO", "BAR"]
		};

		var json = JsonSerializer.Serialize(synchronizedBeneficiary, JsonSerializerOptions.Web);
		Contains("\"bankName\":\"My Bank\"", json);
		Contains("\"erpId\":\"MC2IT-DEVELOPMENT\"", json);
		Contains("\"name\":\"My Company\"", json);
		Contains("\"supplierErpIds\":[\"FOO\",\"BAR\"]", json);
		DoesNotContain("\"accountNumber\"", json);
		DoesNotContain("\"postalAddress\"", json);
	}
}
