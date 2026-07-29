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
		AreEqual("My Bank", beneficiary.BankAccount?.BankName);
		AreEqual("Paris", beneficiary.PostalAddress?.City);
		IsNull(beneficiary.CompanyLegalIdentifier);
		AreEqual(new Guid("e4cd6d44-4d22-445f-909b-e55e59ad0436"), beneficiary.Id);
		AreEqual("My Company", beneficiary.Name);
		AreEqual(UncertaintyStatus.Uncertain, beneficiary.UncertaintyStatus);
		IsNull(beneficiary.ValidationStatus);
	}

	[TestMethod]
	public void ToJson() {
		var beneficiary = new Beneficiary {
			Name = "My Company",
			UncertaintyStatus = UncertaintyStatus.NotUncertain
		};

		var json = JsonSerializer.Serialize(beneficiary, JsonSerializerOptions.Web);
		Contains("\"name\":\"My Company\"", json);
		Contains("\"uncertaintyStatus\":\"NotUncertain\"", json);
		DoesNotContain("\"bankAccount\"", json);
		DoesNotContain("\"id\"", json);
		DoesNotContain("\"postalAddress\"", json);
	}
}
