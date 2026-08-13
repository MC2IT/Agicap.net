namespace Mc2it.Agicap.TreasuryBankJournal;

/// <summary>
/// Tests the features of the <see cref="ExportApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class ExportApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly ExportApi api = Fixtures.CreateClient().TreasuryBankJournal.Exports(Fixtures.EntityId);

	[TestMethod, Ignore("This test requires an Agicap development environment.")]
	public void Create() => Inconclusive();

	[TestMethod]
	public async Task Read() {
		var bankJournalExport = await api.ReadAsync(new Guid("575d62e4-e965-49fd-9a2d-b53bb1ad5434"), testContext.CancellationToken);
		AreEqual("MC2IT", bankJournalExport.EntityName);
		HasCount(5, bankJournalExport.Entries);
		AreEqual(2026, bankJournalExport.Year);

		var bankJournalEntry = bankJournalExport.Entries.Last();
		AreEqual("EUR", bankJournalEntry.AccountingCurrency);
		IsNull(bankJournalEntry.Causale);
		HasCount(1, bankJournalEntry.Counterparts);
		StartsWith("MC2IT", bankJournalEntry.Counterparts.First().Name);
		IsNull(bankJournalEntry.EntryMemo);
		StartsWith("MC2IT", bankJournalEntry.Name);
		AreEqual("EUR", bankJournalEntry.OriginalCurrency);
	}

	[TestMethod]
	public async Task ReadAll() {
		var list = await api.ReadAllAsync(before: new DateTime(2026, 7, 21, 23, 59, 59, DateTimeKind.Utc), cancellationToken: testContext.CancellationToken);
		HasCount(3, list.Items);

		var exportSummary = list.Items.First();
		AreEqual(new DateTime(2026, 7, 21, 13, 52, 44, 861, DateTimeKind.Utc), exportSummary.ExportDateUtc);
		AreNotEqual(Guid.Empty, exportSummary.ExportId);
		IsGreaterThan(1, exportSummary.ExportIndexInYear);
		AreEqual(2026, exportSummary.ExportYear);
		IsGreaterThan(1, exportSummary.IndexInYearOfFirstEntryInBankJournal);
		IsGreaterThan(1, exportSummary.IndexInYearOfLastEntryInBankJournal);
		AreEqual(222, exportSummary.NumberOfEntries);
	}
}
