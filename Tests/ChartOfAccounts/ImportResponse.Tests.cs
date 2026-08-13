namespace Mc2it.Agicap.ChartOfAccounts;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="ImportResponse"/> class.
/// </summary>
[TestClass]
public sealed class ImportResponseTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/ChartOfAccounts/ImportResponse.json"));
		var importResponse = JsonSerializer.Deserialize<ImportResponse>(json, JsonSerializerOptions.Web)!;

		IsNull(importResponse.FailureReason);
		AreEqual(new DateTime(2026, 8, 6, 8, 35, 21, DateTimeKind.Utc), importResponse.ImportDate);
		AreNotEqual(Guid.Empty, importResponse.ImportId);
		AreEqual(ImportStatus.Done, importResponse.ImportStatus);
		IsNotNull(importResponse.ImportSummary);
		AreEqual(1, importResponse.ImportSummary.ImportedCount);
		AreEqual(3, importResponse.ImportSummary.NotImportedCount);
	}
}
