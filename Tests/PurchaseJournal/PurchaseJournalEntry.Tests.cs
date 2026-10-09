namespace Mc2it.Agicap.PurchaseJournal;

using System.Globalization;
using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="PurchaseJournalEntry"/> class.
/// </summary>
[TestClass]
public class PurchaseJournalEntryTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/PurchaseJournal/PurchaseJournalEntry.json"));
		var purchaseJournalEntry = JsonSerializer.Deserialize<PurchaseJournalEntry>(json, JsonSerializerOptions.Web)!;

		purchaseJournalEntry.AccountingLines.Count.ShouldBe(3);
		purchaseJournalEntry.AccountingLines.Sum(accountingLine => accountingLine.Credit - accountingLine.Debit).ShouldBe(0);
		purchaseJournalEntry.AccountingLines.All(accountingLine => accountingLine.Currency == "USD").ShouldBeTrue();

		purchaseJournalEntry.AgicapUniqueId.ShouldBe(new Guid("d3b07384-d9a3-4e5d-8c7c-8f9f1c2b3a4b"));
		purchaseJournalEntry.BillingDate.ShouldBe(DateTime.Parse("2024-12-16T00:00:00", CultureInfo.InvariantCulture));
		purchaseJournalEntry.DueDate.ShouldBe(DateTime.Parse("2024-12-16", CultureInfo.InvariantCulture));
		purchaseJournalEntry.InvoiceOrReceiptNumber.ShouldBe("20241216");
		purchaseJournalEntry.Note.ShouldBe("OVH invoice for december");
		purchaseJournalEntry.OrderNumbers.ShouldBe(["20241216"]);
		purchaseJournalEntry.OriginalFileExtension.ShouldBe("pdf");
		purchaseJournalEntry.OriginalFileUrl.ShouldBe(new Uri("https://agicap.com/invoice1.pdf"));
		purchaseJournalEntry.PaymentMethod.ShouldBe(PaymentMethod.DebitCard);
		purchaseJournalEntry.PerformanceDate.ShouldBe(DateTime.Parse("2024-12-16T00:00:00", CultureInfo.InvariantCulture));
		purchaseJournalEntry.PrepaidExpenseEndDate.ShouldBe(DateTime.Parse("2024-12-16", CultureInfo.InvariantCulture));
		purchaseJournalEntry.PrepaidExpenseStartDate.ShouldBe(DateTime.Parse("2024-12-16", CultureInfo.InvariantCulture));
		purchaseJournalEntry.SupplierErpExternalId.ShouldBe("ERP-OVH-001");
		purchaseJournalEntry.SupplierOrMerchant.ShouldBe("OVH");
		purchaseJournalEntry.Title.ShouldBe("Invoice OVH December 2024");
		purchaseJournalEntry.Typology.ShouldBe(Typology.OwedInvoice);
		purchaseJournalEntry.UniqueId.ShouldBe("78dwxxd5");

		// TODO: test the `PurchaseJournalEntry.InvoiceInformation` property when it will be implemented.
	}
}
