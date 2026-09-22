namespace Mc2it.Agicap;

using Mc2it.Agicap.Organizations;
using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Cursor"/> class.
/// </summary>
[TestClass]
public sealed class CursorTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Cursor.json"));
		var cursor = JsonSerializer.Deserialize<Cursor>(json, JsonSerializerOptions.Web)!;

		Assert.IsNull(cursor.After);
		Assert.AreEqual(new DateTime(2026, 6, 25, 8, 14, 52, DateTimeKind.Utc), cursor.Before);
		Assert.AreEqual(247, cursor.Size);
	}
}

/// <summary>
/// Tests the features of the <see cref="CursorPaginatedList"/> class.
/// </summary>
[TestClass]
public sealed class CursorPaginatedListTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/CursorPaginatedList.json"));
		var list = JsonSerializer.Deserialize<CursorPaginatedList<Organization>>(json, JsonSerializerOptions.Web)!;
		Assert.HasCount(2, list.Items);

		var firstItem = list.Items.First();
		Assert.AreEqual(new Guid("3ebb0163-6ac8-449d-a34b-496244f380a1"), firstItem.Id);
		Assert.AreEqual("Company #1", firstItem.Name);

		var lastItem = list.Items.Last();
		Assert.AreEqual(new Guid("866faf6e-19c3-4131-97da-c50ff9a92961"), lastItem.Id);
		Assert.AreEqual("Company #2", lastItem.Name);

		var cursor = list.Cursor;
		Assert.IsNull(cursor.After);
		Assert.AreEqual(new DateTime(2026, 6, 25, 8, 14, 52, DateTimeKind.Utc), cursor.Before);
		Assert.AreEqual(247, cursor.Size);
	}
}
