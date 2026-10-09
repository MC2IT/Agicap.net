namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="SynchronizedBeneficiary"/> class.
/// </summary>
[TestClass]
public class SynchronizedBeneficiaryTests {

	[TestMethod]
	public void FromBeneficiary() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/Beneficiary.json"));
		var synchronizedBeneficiary = new SynchronizedBeneficiary("MC2IT-DEVELOPMENT", JsonSerializer.Deserialize<Beneficiary>(json, JsonSerializerOptions.Web)!);

		synchronizedBeneficiary.AccountNumber.ShouldBe("FR7630006000011234567890189");
		synchronizedBeneficiary.BankCountry.ShouldBe("FR");
		synchronizedBeneficiary.BankIdentifier.ShouldBe("BNPAFRPPXXX");
		synchronizedBeneficiary.BankName.ShouldBe("My Bank");
		synchronizedBeneficiary.CompanyLegalId.ShouldBeNull();
		synchronizedBeneficiary.ErpId.ShouldBe("MC2IT-DEVELOPMENT");
		synchronizedBeneficiary.Name.ShouldBe("My Company");
		synchronizedBeneficiary.PostalAddress?.Country.ShouldBe("FR");
		synchronizedBeneficiary.SupplierErpIds.ShouldBeNull();
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
		json.ShouldContain("\"bankName\":\"My Bank\"");
		json.ShouldContain("\"erpId\":\"MC2IT-DEVELOPMENT\"");
		json.ShouldContain("\"name\":\"My Company\"");
		json.ShouldContain("\"supplierErpIds\":[\"FOO\",\"BAR\"]");
		json.ShouldNotContain("\"accountNumber\"");
		json.ShouldNotContain("\"postalAddress\"");
	}
}
