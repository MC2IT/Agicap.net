namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="CustomField"/> class.
/// </summary>
[TestClass]
public class CustomFieldTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/CustomField.json"));
		var customField = JsonSerializer.Deserialize<CustomField>(json, JsonSerializerOptions.Web)!;

		customField.Name.ShouldBe("Company division");
		customField.Value.ShouldBe("Cars");
	}
}
