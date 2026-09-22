namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Document"/> class.
/// </summary>
[TestClass]
public sealed class DocumentTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/Document.json"));
		var document = JsonSerializer.Deserialize<Document>(json, JsonSerializerOptions.Web)!;

		Assert.IsNull(document.DocumentIssueDate);
		Assert.AreEqual("INV-2025-0002", document.DocumentReference);
		Assert.AreEqual(DocumentType.SUPPLIER_INVOICE, document.DocumentType);
		Assert.IsNull(document.ExternalEntityId);
		Assert.AreEqual("37cfb760-8f09-4fc1-8269-18f92e6e90e4", document.ExternalId);
		Assert.AreEqual(new DateTime(2025, 12, 21), document.OriginalDueDate);
		Assert.AreEqual("2wrrwpou", document.UniqueId);
	}
}
