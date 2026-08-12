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

		AreEqual("41100000", thirdParty.AccountingAccountNumber);
		IsNull(thirdParty.ExternalId);
		AreEqual("MC2IT-DEVELOPMENT", thirdParty.ThirdPartyCode);
		AreEqual("MC2IT Development Department", thirdParty.ThirdPartyName);
	}

	[TestMethod]
	public void ToJson() {
		var thirdParty = new ThirdParty {
			AccountingAccountNumber = "41100000",
			ThirdPartyCode = "MC2IT-DEVELOPMENT",
			ThirdPartyName = "MC2IT Development Department"
		};

		var json = JsonSerializer.Serialize(thirdParty, JsonSerializerOptions.Web);
		Contains("\"accountingAccountNumber\":\"41100000\"", json);
		Contains("\"thirdPartyCode\":\"MC2IT-DEVELOPMENT\"", json);
		Contains("\"thirdPartyName\":\"MC2IT Development Department\"", json);
		DoesNotContain("\"externalId\"", json);
	}
}
