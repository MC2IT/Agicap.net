namespace Mc2it.Agicap;

using Mc2it.Agicap.Organizations;
using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="CursorPaginatedList"/> class.
/// </summary>
[TestClass]
public sealed class CursorPaginatedListTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/CursorPaginatedList.json"));
		var list = JsonSerializer.Deserialize<CursorPaginatedList<Organization>>(json, JsonSerializerOptions.Web)!;
		HasCount(2, list.Items);

		var organization = list.Items.First();
		AreEqual(new Guid("3ebb0163-6ac8-449d-a34b-496244f380a1"), organization.Id);
		AreEqual("Company #1", organization.Name);

		organization = list.Items.Last();
		AreEqual(new Guid("866faf6e-19c3-4131-97da-c50ff9a92961"), organization.Id);
		AreEqual("Company #2", organization.Name);

		var cursor = list.Cursor;
		IsNull(cursor.After);
		AreEqual(new DateTime(2026, 6, 25, 8, 14, 52, DateTimeKind.Utc), cursor.Before);
		AreEqual(247, cursor.Size);
	}
}
