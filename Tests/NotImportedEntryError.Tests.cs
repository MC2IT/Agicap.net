namespace Mc2it.Agicap;

using System.Text.Json;

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
