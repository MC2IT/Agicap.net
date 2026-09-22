namespace Mc2it.Agicap.Suppliers;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="LegalAddress"/> class.
/// </summary>
[TestClass]
public sealed class LegalAddressTests {

	[TestMethod]
	public void IsEmpty() {
		Assert.IsTrue(new LegalAddress().IsEmpty);
		Assert.IsTrue(new LegalAddress { City = " ", Country = " ", StreetName = " " }.IsEmpty);
	}

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Suppliers/LegalAddress.json"));
		var postalAddress = JsonSerializer.Deserialize<LegalAddress>(json, JsonSerializerOptions.Web)!;

		Assert.AreEqual("Paris", postalAddress.City);
		Assert.AreEqual("FR", postalAddress.Country);
		Assert.IsNull(postalAddress.Number);
		Assert.AreEqual("75000", postalAddress.PostalCode);
		Assert.IsNull(postalAddress.State);
		Assert.AreEqual("Rue de la Paix", postalAddress.StreetName);
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
		Assert.Contains("\"city\":\"Paris\"", json);
		Assert.Contains("\"postalCode\":\"75000\"", json);
		Assert.DoesNotContain("\"number\"", json);
		Assert.DoesNotContain("\"state\"", json);
	}
}
