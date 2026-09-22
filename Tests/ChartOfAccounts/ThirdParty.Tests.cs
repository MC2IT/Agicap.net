namespace Mc2it.Agicap.ChartOfAccounts;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="ThirdParty"/> class.
/// </summary>
[TestClass]
public sealed class ThirdPartyTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/ChartOfAccounts/ThirdParty.json"));
		var thirdParty = JsonSerializer.Deserialize<ThirdParty>(json, JsonSerializerOptions.Web)!;

		Assert.AreEqual("41100000", thirdParty.AccountingAccountNumber);
		Assert.IsNull(thirdParty.ExternalId);
		Assert.AreEqual("MC2IT-DEVELOPMENT", thirdParty.ThirdPartyCode);
		Assert.AreEqual("MC2IT Development Department", thirdParty.ThirdPartyName);
	}

	[TestMethod]
	public void ToJson() {
		var thirdParty = new ThirdParty {
			AccountingAccountNumber = "41100000",
			ThirdPartyCode = "MC2IT-DEVELOPMENT",
			ThirdPartyName = "MC2IT Development Department"
		};

		var json = JsonSerializer.Serialize(thirdParty, JsonSerializerOptions.Web);
		Assert.Contains("\"accountingAccountNumber\":\"41100000\"", json);
		Assert.Contains("\"thirdPartyCode\":\"MC2IT-DEVELOPMENT\"", json);
		Assert.Contains("\"thirdPartyName\":\"MC2IT Development Department\"", json);
		Assert.DoesNotContain("\"externalId\"", json);
	}
}
