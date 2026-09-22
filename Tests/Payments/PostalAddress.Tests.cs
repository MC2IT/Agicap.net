namespace Mc2it.Agicap.Payments;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="PostalAddress"/> class.
/// </summary>
[TestClass]
public sealed class PostalAddressTests {

	[TestMethod]
	public void IsEmpty() {
		Assert.IsTrue(new PostalAddress().IsEmpty);
		Assert.IsTrue(new PostalAddress { City = " ", Country = " ", StreetName = " " }.IsEmpty);
	}

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Payments/PostalAddress.json"));
		var postalAddress = JsonSerializer.Deserialize<PostalAddress>(json, JsonSerializerOptions.Web)!;

		Assert.AreEqual("Paris", postalAddress.City);
		Assert.AreEqual("FR", postalAddress.Country);
		Assert.IsNull(postalAddress.Number);
		Assert.IsNull(postalAddress.State);
		Assert.AreEqual("Rue de la Paix", postalAddress.StreetName);
		Assert.AreEqual("75000", postalAddress.ZipCode);
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
		Assert.Contains("\"city\":\"Paris\"", json);
		Assert.Contains("\"zipCode\":\"75000\"", json);
		Assert.DoesNotContain("\"number\"", json);
		Assert.DoesNotContain("\"state\"", json);
	}
}
