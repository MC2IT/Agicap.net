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

		Assert.IsNull(importResponse.FailureReason);
		Assert.AreEqual(new DateTime(2026, 8, 6, 8, 35, 21, DateTimeKind.Utc), importResponse.ImportDate);
		Assert.AreNotEqual(Guid.Empty, importResponse.ImportId);
		Assert.AreEqual(ImportStatus.Done, importResponse.ImportStatus);
		Assert.IsNotNull(importResponse.ImportSummary);
		Assert.AreEqual(1, importResponse.ImportSummary.ImportedCount);
		Assert.AreEqual(3, importResponse.ImportSummary.NotImportedCount);
	}
}
