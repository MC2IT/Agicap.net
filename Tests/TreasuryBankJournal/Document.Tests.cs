namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="Document"/> class.
/// </summary>
[TestClass]
public class DocumentTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/TreasuryBankJournal/Document.json"));
		var document = JsonSerializer.Deserialize<Document>(json, JsonSerializerOptions.Web)!;

		document.DocumentIssueDate.ShouldBeNull();
		document.DocumentReference.ShouldBe("INV-2025-0002");
		document.DocumentType.ShouldBe(DocumentType.SUPPLIER_INVOICE);
		document.ExternalEntityId.ShouldBeNull();
		document.ExternalId.ShouldBe("37cfb760-8f09-4fc1-8269-18f92e6e90e4");
		document.OriginalDueDate.ShouldBe(new DateTime(2025, 12, 21));
		document.UniqueId.ShouldBe("2wrrwpou");
	}
}
