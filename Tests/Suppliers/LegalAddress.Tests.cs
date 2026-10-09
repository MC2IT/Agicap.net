namespace Mc2it.Agicap.Suppliers;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="LegalAddress"/> class.
/// </summary>
[TestClass]
public class LegalAddressTests {

	[TestMethod]
	public void IsEmpty() {
		new LegalAddress().IsEmpty.ShouldBeTrue();
		new LegalAddress { City = " ", Country = " ", StreetName = " " }.IsEmpty.ShouldBeTrue();
	}

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Suppliers/LegalAddress.json"));
		var postalAddress = JsonSerializer.Deserialize<LegalAddress>(json, JsonSerializerOptions.Web)!;

		postalAddress.City.ShouldBe("Paris");
		postalAddress.Country.ShouldBe("FR");
		postalAddress.Number.ShouldBeNull();
		postalAddress.PostalCode.ShouldBe("75000");
		postalAddress.State.ShouldBeNull();
		postalAddress.StreetName.ShouldBe("Rue de la Paix");
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
		json.ShouldContain("\"city\":\"Paris\"");
		json.ShouldContain("\"postalCode\":\"75000\"");
		json.ShouldNotContain("\"number\"");
		json.ShouldNotContain("\"state\"");
	}
}
