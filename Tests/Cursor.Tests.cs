namespace Mc2it.Agicap;

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

		IsNull(cursor.After);
		AreEqual(new DateTime(2026, 6, 25, 8, 14, 52, DateTimeKind.Utc), cursor.Before);
		AreEqual(247, cursor.Size);
	}
}
