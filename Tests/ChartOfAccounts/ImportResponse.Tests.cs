namespace Mc2it.Agicap.ChartOfAccounts;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="ImportResponse"/> class.
/// </summary>
[TestClass]
public class ImportResponseTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/ChartOfAccounts/ImportResponse.json"));
		var importResponse = JsonSerializer.Deserialize<ImportResponse>(json, JsonSerializerOptions.Web)!;

		importResponse.FailureReason.ShouldBeNull();
		importResponse.ImportDate.ShouldBe(new DateTime(2026, 8, 6, 8, 35, 21, DateTimeKind.Utc));
		importResponse.ImportId.ShouldNotBe(Guid.Empty);
		importResponse.ImportStatus.ShouldBe(ImportStatus.Done);
		importResponse.ImportSummary.ShouldNotBeNull();
		importResponse.ImportSummary.ImportedCount.ShouldBe(1);
		importResponse.ImportSummary.NotImportedCount.ShouldBe(3);
	}
}
