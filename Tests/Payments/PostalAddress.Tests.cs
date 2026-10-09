namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="PostalAddress"/> class.
/// </summary>
[TestClass]
public class PostalAddressTests {

	[TestMethod]
	public void IsEmpty() {
		new PostalAddress().IsEmpty.ShouldBeTrue();
		new PostalAddress { City = " ", Country = " ", StreetName = " " }.IsEmpty.ShouldBeTrue();
	}

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/PostalAddress.json"));
		var postalAddress = JsonSerializer.Deserialize<PostalAddress>(json, JsonSerializerOptions.Web)!;

		postalAddress.City.ShouldBe("Paris");
		postalAddress.Country.ShouldBe("FR");
		postalAddress.Number.ShouldBeNull();
		postalAddress.State.ShouldBeNull();
		postalAddress.StreetName.ShouldBe("Rue de la Paix");
		postalAddress.ZipCode.ShouldBe("75000");
	}

	[TestMethod]
	public void ToJson() {
		var postalAddress = new PostalAddress {
			City = "Paris",
			Country = "FR",
			StreetName = "Rue de la Paix",
			ZipCode = "75000"
		};

		var json = JsonSerializer.Serialize(postalAddress, JsonSerializerOptions.Web);
		json.ShouldContain("\"city\":\"Paris\"");
		json.ShouldContain("\"zipCode\":\"75000\"");
		json.ShouldNotContain("\"number\"");
		json.ShouldNotContain("\"state\"");
	}
}
