namespace Mc2it.Agicap.Suppliers;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="LegalAddress"/> class.
/// </summary>
[TestClass]
public sealed class LegalAddressTests {

	[TestMethod]
	public void IsEmpty() {
		IsTrue(new LegalAddress().IsEmpty);
		IsTrue(new LegalAddress { City = " ", Country = " ", StreetName = " " }.IsEmpty);
	}

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Suppliers/LegalAddress.json"));
		var postalAddress = JsonSerializer.Deserialize<LegalAddress>(json, JsonSerializerOptions.Web)!;
		AreEqual("Paris", postalAddress.City);
		AreEqual("FR", postalAddress.Country);
		IsNull(postalAddress.Number);
		AreEqual("75000", postalAddress.PostalCode);
		IsNull(postalAddress.State);
		AreEqual("Rue de la Paix", postalAddress.StreetName);
	}

	[TestMethod]
	public void ToJson() {
		var postalAddress = new LegalAddress {
			City = "Paris",
			Country = "FR",
			PostalCode = "75000",
			StreetName = "Rue de la Paix"
		};

		var json = JsonSerializer.Serialize(postalAddress, JsonSerializerOptions.Web);
		Contains("\"city\":\"Paris\"", json);
		Contains("\"postalCode\":\"75000\"", json);
		DoesNotContain("\"number\"", json);
		DoesNotContain("\"state\"", json);
	}
}
