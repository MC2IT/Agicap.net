namespace Mc2it.Agicap.PurchaseJournal;

using System.Globalization;
using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="PurchaseJournalEntry"/> class.
/// </summary>
[TestClass]
public sealed class PurchaseJournalEntryTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/PurchaseJournal/PurchaseJournalEntry.json"));
		var purchaseJournalEntry = JsonSerializer.Deserialize<PurchaseJournalEntry>(json, JsonSerializerOptions.Web)!;

		HasCount(3, purchaseJournalEntry.AccountingLines);
		AreEqual(0, purchaseJournalEntry.AccountingLines.Sum(accountingLine => accountingLine.Credit - accountingLine.Debit));
		AreEqual(new Guid("d3b07384-d9a3-4e5d-8c7c-8f9f1c2b3a4b"), purchaseJournalEntry.AgicapUniqueId);
		AreEqual(DateTime.Parse("2024-12-16T00:00:00", CultureInfo.InvariantCulture), purchaseJournalEntry.BillingDate);
		AreEqual(DateTime.Parse("2024-12-16", CultureInfo.InvariantCulture), purchaseJournalEntry.DueDate);
		AreEqual("20241216", purchaseJournalEntry.InvoiceOrReceiptNumber);
		AreEqual("OVH invoice for december", purchaseJournalEntry.Note);
		AreSequenceEqual(["20241216"], purchaseJournalEntry.OrderNumbers);
		AreEqual("pdf", purchaseJournalEntry.OriginalFileExtension);
		AreEqual(new Uri("https://agicap.com/invoice1.pdf"), purchaseJournalEntry.OriginalFileUrl);
		AreEqual(PaymentMethod.DebitCard, purchaseJournalEntry.PaymentMethod);
		AreEqual(DateTime.Parse("2024-12-16T00:00:00", CultureInfo.InvariantCulture), purchaseJournalEntry.PerformanceDate);
		AreEqual(DateTime.Parse("2024-12-16", CultureInfo.InvariantCulture), purchaseJournalEntry.PrepaidExpenseEndDate);
		AreEqual(DateTime.Parse("2024-12-16", CultureInfo.InvariantCulture), purchaseJournalEntry.PrepaidExpenseStartDate);
		AreEqual("ERP-OVH-001", purchaseJournalEntry.SupplierErpExternalId);
		AreEqual("OVH", purchaseJournalEntry.SupplierOrMerchant);
		AreEqual("Invoice OVH December 2024", purchaseJournalEntry.Title);
		AreEqual(Typology.OwedInvoice, purchaseJournalEntry.Typology);
		AreEqual("78dwxxd5", purchaseJournalEntry.UniqueId);

		// TODO: test the `PurchaseJournalEntry.InvoiceInformation` property when it will be implemented.
	}
}
