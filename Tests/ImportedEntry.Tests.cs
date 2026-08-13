namespace Mc2it.Agicap;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="ImportedEntry"/> class.
/// </summary>
[TestClass]
public sealed class ImportedEntryTests {

	[TestMethod]
	public void ToJson() {
		var guid = Guid.NewGuid();
		var notImportedEntry = new ImportedEntry { EntryAgicapUniqueId = guid };
		var json = JsonSerializer.Serialize(notImportedEntry, JsonSerializerOptions.Web);
		Contains($"\"entryAgicapUniqueId\":\"{guid}\"", json);
	}
}
