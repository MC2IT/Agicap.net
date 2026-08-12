namespace Mc2it.Agicap.Organizations;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Organization"/> class.
/// </summary>
[TestClass]
public sealed class OrganizationTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Organizations/Organization.json"));
		var organization = JsonSerializer.Deserialize<Organization>(json, JsonSerializerOptions.Web)!;

		AreEqual(new Guid("3ebb0163-6ac8-449d-a34b-496244f380a1"), organization.Id);
		AreEqual("My Company", organization.Name);
	}
}
