namespace Mc2it.Agicap.PurchaseJournal;

/// <summary>
/// Tests the features of the <see cref="AccountingPurchaseApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class AccountingPurchaseApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly AccountingPurchaseApi api = Fixtures.CreateClient().PurchaseJournal.AccountingPurchases(Fixtures.EntityId);

	[TestMethod, Ignore("This test requires an Agicap development environment.")]
	public void MarkAsNotImported() => Inconclusive();

	[TestMethod]
	public async Task ReadAll() {
		var lastSynchronizationDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		var purchaseJournalEntries = (await api.ReadAllAsync(lastSynchronizationDate, pageSize: 2, cancellationToken: testContext.CancellationToken)).Items;
		HasCount(2, purchaseJournalEntries);

		foreach (var purchaseJournalEntry in purchaseJournalEntries) {
			AreNotEqual(Guid.Empty, purchaseJournalEntry.AgicapUniqueId);
			IsGreaterThanOrEqualTo(1, purchaseJournalEntry.AccountingLines.Count);
			AreEqual(0, purchaseJournalEntry.AccountingLines.Sum(accountingLine => accountingLine.Credit - accountingLine.Debit));
			IsTrue(purchaseJournalEntry.AccountingLines.All(accountingLine => accountingLine.Currency == "EUR"));
		}
	}
}
