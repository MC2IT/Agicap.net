namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Beneficiary"/> class.
/// </summary>
[TestClass]
public class BeneficiaryTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/Beneficiary.json"));
		var beneficiary = JsonSerializer.Deserialize<Beneficiary>(json, JsonSerializerOptions.Web)!;

		beneficiary.BankAccount?.BankName.ShouldBe("My Bank");
		beneficiary.BankAccount?.Bic.ShouldBe("BNPAFRPPXXX");
		beneficiary.BankAccount?.Identifier.ShouldBe("FR7630006000011234567890189");
		beneficiary.PostalAddress?.City.ShouldBe("Paris");
		beneficiary.PostalAddress?.Country.ShouldBe("FR");
		beneficiary.CompanyLegalIdentifier.ShouldBeNull();
		beneficiary.Id.ShouldBe(new Guid("e4cd6d44-4d22-445f-909b-e55e59ad0436"));
		beneficiary.Name.ShouldBe("My Company");
		beneficiary.UncertaintyStatus.ShouldBe(UncertaintyStatus.Uncertain);
		beneficiary.ValidationStatus.ShouldBeNull();
	}

	[TestMethod]
	public void ToJson() {
		var beneficiary = new Beneficiary { Name = "My Company", PostalAddress = new() };
		var json = JsonSerializer.Serialize(beneficiary, JsonSerializerOptions.Web);
		json.ShouldContain("\"name\":\"My Company\"");
		json.ShouldNotContain("\"bankAccount\"");
		json.ShouldNotContain("\"id\"");
		json.ShouldNotContain("\"postalAddress\"");
	}
}
