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

		Assert.HasCount(3, purchaseJournalEntry.AccountingLines);
		Assert.AreEqual(0, purchaseJournalEntry.AccountingLines.Sum(accountingLine => accountingLine.Credit - accountingLine.Debit));
		Assert.IsTrue(purchaseJournalEntry.AccountingLines.All(accountingLine => accountingLine.Currency == "USD"));

		Assert.AreEqual(new Guid("d3b07384-d9a3-4e5d-8c7c-8f9f1c2b3a4b"), purchaseJournalEntry.AgicapUniqueId);
		Assert.AreEqual(DateTime.Parse("2024-12-16T00:00:00", CultureInfo.InvariantCulture), purchaseJournalEntry.BillingDate);
		Assert.AreEqual(DateTime.Parse("2024-12-16", CultureInfo.InvariantCulture), purchaseJournalEntry.DueDate);
		Assert.AreEqual("20241216", purchaseJournalEntry.InvoiceOrReceiptNumber);
		Assert.AreEqual("OVH invoice for december", purchaseJournalEntry.Note);
		Assert.AreSequenceEqual(["20241216"], purchaseJournalEntry.OrderNumbers);
		Assert.AreEqual("pdf", purchaseJournalEntry.OriginalFileExtension);
		Assert.AreEqual(new Uri("https://agicap.com/invoice1.pdf"), purchaseJournalEntry.OriginalFileUrl);
		Assert.AreEqual(PaymentMethod.DebitCard, purchaseJournalEntry.PaymentMethod);
		Assert.AreEqual(DateTime.Parse("2024-12-16T00:00:00", CultureInfo.InvariantCulture), purchaseJournalEntry.PerformanceDate);
		Assert.AreEqual(DateTime.Parse("2024-12-16", CultureInfo.InvariantCulture), purchaseJournalEntry.PrepaidExpenseEndDate);
		Assert.AreEqual(DateTime.Parse("2024-12-16", CultureInfo.InvariantCulture), purchaseJournalEntry.PrepaidExpenseStartDate);
		Assert.AreEqual("ERP-OVH-001", purchaseJournalEntry.SupplierErpExternalId);
		Assert.AreEqual("OVH", purchaseJournalEntry.SupplierOrMerchant);
		Assert.AreEqual("Invoice OVH December 2024", purchaseJournalEntry.Title);
		Assert.AreEqual(Typology.OwedInvoice, purchaseJournalEntry.Typology);
		Assert.AreEqual("78dwxxd5", purchaseJournalEntry.UniqueId);

		// TODO: test the `PurchaseJournalEntry.InvoiceInformation` property when it will be implemented.
	}
}
