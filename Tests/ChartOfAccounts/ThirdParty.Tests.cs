namespace Mc2it.Agicap.ChartOfAccounts;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="ThirdParty"/> class.
/// </summary>
[TestClass]
public class ThirdPartyTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/ChartOfAccounts/ThirdParty.json"));
		var thirdParty = JsonSerializer.Deserialize<ThirdParty>(json, JsonSerializerOptions.Web)!;

		thirdParty.AccountingAccountNumber.ShouldBe("41100000");
		thirdParty.ExternalId.ShouldBeNull();
		thirdParty.ThirdPartyCode.ShouldBe("MC2IT-DEVELOPMENT");
		thirdParty.ThirdPartyName.ShouldBe("MC2IT Development Department");
	}

	[TestMethod]
	public void ToJson() {
		var thirdParty = new ThirdParty {
			AccountingAccountNumber = "41100000",
			ThirdPartyCode = "MC2IT-DEVELOPMENT",
			ThirdPartyName = "MC2IT Development Department"
		};

		var json = JsonSerializer.Serialize(thirdParty, JsonSerializerOptions.Web);
		json.ShouldContain("\"accountingAccountNumber\":\"41100000\"");
		json.ShouldContain("\"thirdPartyCode\":\"MC2IT-DEVELOPMENT\"");
		json.ShouldContain("\"thirdPartyName\":\"MC2IT Development Department\"");
		json.ShouldNotContain("\"externalId\"");
	}
}
