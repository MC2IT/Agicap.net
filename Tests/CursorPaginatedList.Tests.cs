namespace Mc2it.Agicap;

using Mc2it.Agicap.Organizations;
using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Cursor"/> class.
/// </summary>
[TestClass]
public class CursorTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Cursor.json"));
		var cursor = JsonSerializer.Deserialize<Cursor>(json, JsonSerializerOptions.Web)!;

		cursor.After.ShouldBeNull();
		cursor.Before.ShouldBe(new DateTime(2026, 6, 25, 8, 14, 52, DateTimeKind.Utc));
		cursor.Size.ShouldBe(247);
	}
}

/// <summary>
/// Tests the features of the <see cref="CursorPaginatedList"/> class.
/// </summary>
[TestClass]
public class CursorPaginatedListTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/CursorPaginatedList.json"));
		var list = JsonSerializer.Deserialize<CursorPaginatedList<Organization>>(json, JsonSerializerOptions.Web)!;
		list.Items.Count.ShouldBe(2);

		var firstItem = list.Items.First();
		firstItem.Id.ShouldBe(new Guid("3ebb0163-6ac8-449d-a34b-496244f380a1"));
		firstItem.Name.ShouldBe("Company #1");

		var lastItem = list.Items.Last();
		lastItem.Id.ShouldBe(new Guid("866faf6e-19c3-4131-97da-c50ff9a92961"));
		lastItem.Name.ShouldBe("Company #2");

		var cursor = list.Cursor;
		cursor.After.ShouldBeNull();
		cursor.Before.ShouldBe(new DateTime(2026, 6, 25, 8, 14, 52, DateTimeKind.Utc));
		cursor.Size.ShouldBe(247);
	}
}
