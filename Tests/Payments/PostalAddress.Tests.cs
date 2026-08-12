namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="PostalAddress"/> class.
/// </summary>
[TestClass]
public sealed class PostalAddressTests {

	[TestMethod]
	public void IsEmpty() {
		IsTrue(new PostalAddress().IsEmpty);
		IsTrue(new PostalAddress { City = " ", Country = " ", StreetName = " " }.IsEmpty);
	}

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/PostalAddress.json"));
		var postalAddress = JsonSerializer.Deserialize<PostalAddress>(json, JsonSerializerOptions.Web)!;

		AreEqual("Paris", postalAddress.City);
		AreEqual("FR", postalAddress.Country);
		IsNull(postalAddress.Number);
		IsNull(postalAddress.State);
		AreEqual("Rue de la Paix", postalAddress.StreetName);
		AreEqual("75000", postalAddress.ZipCode);
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
		Contains("\"city\":\"Paris\"", json);
		Contains("\"zipCode\":\"75000\"", json);
		DoesNotContain("\"number\"", json);
		DoesNotContain("\"state\"", json);
	}
}
