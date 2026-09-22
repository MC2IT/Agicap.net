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

		Assert.AreEqual("FR7630006000011234567890189", synchronizedBeneficiary.AccountNumber);
		Assert.AreEqual("FR", synchronizedBeneficiary.BankCountry);
		Assert.AreEqual("BNPAFRPPXXX", synchronizedBeneficiary.BankIdentifier);
		Assert.AreEqual("My Bank", synchronizedBeneficiary.BankName);
		Assert.IsNull(synchronizedBeneficiary.CompanyLegalId);
		Assert.AreEqual("MC2IT-DEVELOPMENT", synchronizedBeneficiary.ErpId);
		Assert.AreEqual("My Company", synchronizedBeneficiary.Name);
		Assert.AreEqual("FR", synchronizedBeneficiary.PostalAddress?.Country);
		Assert.IsNull(synchronizedBeneficiary.SupplierErpIds);
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
		Assert.Contains("\"bankName\":\"My Bank\"", json);
		Assert.Contains("\"erpId\":\"MC2IT-DEVELOPMENT\"", json);
		Assert.Contains("\"name\":\"My Company\"", json);
		Assert.Contains("\"supplierErpIds\":[\"FOO\",\"BAR\"]", json);
		Assert.DoesNotContain("\"accountNumber\"", json);
		Assert.DoesNotContain("\"postalAddress\"", json);
	}
}
