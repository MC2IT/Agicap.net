namespace Mc2it.Agicap;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="NotImportedEntry"/> class.
/// </summary>
[TestClass]
public sealed class NotImportedEntryTests {

	[TestMethod]
	public void ToJson() {
		var guid = Guid.NewGuid();
		var notImportedEntry = new NotImportedEntry {
			EntryAgicapUniqueId = guid,
			Errors = { new() { ErrorMessage = "An error occurred.", ErrorType = NotImportedEntryErrorTypes.UnknownVatAccount } }
		};

		var json = JsonSerializer.Serialize(notImportedEntry, JsonSerializerOptions.Web);
		Contains($"\"entryAgicapUniqueId\":\"{guid}\"", json);
		Contains("\"errors\":[{", json);
		Contains("\"errorType\":\"UNKNOWN_VAT_ACCOUNT\"", json);
	}
}

/// <summary>
/// Tests the features of the <see cref="NotImportedEntryError"/> class.
/// </summary>
[TestClass]
public sealed class NotImportedEntryErrorTests {

	[TestMethod]
	public void ToJson() {
		var notImportedEntryError = new NotImportedEntryError { ErrorType = NotImportedEntryErrorTypes.UnknownCurrency };
		var json = JsonSerializer.Serialize(notImportedEntryError, JsonSerializerOptions.Web);
		Contains("\"errorType\":\"UNKNOWN_CURRENCY\"", json);
		DoesNotContain("\"errorMessage\"", json);
	}
}
