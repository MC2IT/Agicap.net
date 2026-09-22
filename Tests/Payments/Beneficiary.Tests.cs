namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Beneficiary"/> class.
/// </summary>
[TestClass]
public sealed class BeneficiaryTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/Beneficiary.json"));
		var beneficiary = JsonSerializer.Deserialize<Beneficiary>(json, JsonSerializerOptions.Web)!;

		Assert.AreEqual("My Bank", beneficiary.BankAccount?.BankName);
		Assert.AreEqual("BNPAFRPPXXX", beneficiary.BankAccount?.Bic);
		Assert.AreEqual("FR7630006000011234567890189", beneficiary.BankAccount?.Identifier);
		Assert.AreEqual("Paris", beneficiary.PostalAddress?.City);
		Assert.AreEqual("FR", beneficiary.PostalAddress?.Country);
		Assert.IsNull(beneficiary.CompanyLegalIdentifier);
		Assert.AreEqual(new Guid("e4cd6d44-4d22-445f-909b-e55e59ad0436"), beneficiary.Id);
		Assert.AreEqual("My Company", beneficiary.Name);
		Assert.AreEqual(UncertaintyStatus.Uncertain, beneficiary.UncertaintyStatus);
		Assert.IsNull(beneficiary.ValidationStatus);
	}

	[TestMethod]
	public void ToJson() {
		var beneficiary = new Beneficiary { Name = "My Company", PostalAddress = new() };
		var json = JsonSerializer.Serialize(beneficiary, JsonSerializerOptions.Web);
		Assert.Contains("\"name\":\"My Company\"", json);
		Assert.DoesNotContain("\"bankAccount\"", json);
		Assert.DoesNotContain("\"id\"", json);
		Assert.DoesNotContain("\"postalAddress\"", json);
	}
}
