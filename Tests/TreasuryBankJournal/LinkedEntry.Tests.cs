namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="LinkedEntry"/> class.
/// </summary>
[TestClass]
public sealed class LinkedEntryTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/LinkedEntry.json"));
		var linkedEntry = JsonSerializer.Deserialize<LinkedEntry>(json, JsonSerializerOptions.Web)!;

		AreEqual(new Guid("f7f7ed5c-943c-4385-aa8d-145fd76b2fa1"), linkedEntry.AgicapUniqueId);
		AreEqual("0o00001l", linkedEntry.ExportEntryReference);
	}
}
