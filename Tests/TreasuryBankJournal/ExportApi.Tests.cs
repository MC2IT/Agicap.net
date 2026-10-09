namespace Mc2it.Agicap.TreasuryBankJournal;

/// <summary>
/// Tests the features of the <see cref="ExportApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public class ExportApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly ExportApi api = Fixtures.CreateClient().TreasuryBankJournal.Exports(Fixtures.EntityId);

	[TestMethod, Ignore("This test requires an Agicap development environment.")]
	public void Create() => Assert.Inconclusive();

	[TestMethod, Ignore("This test requires an Agicap development environment.")]
	public void MarkAsImported() => Assert.Inconclusive();

	[TestMethod, Ignore("This test requires an Agicap development environment.")]
	public void MarkAsNotImported() => Assert.Inconclusive();

	[TestMethod]
	public async Task Read() {
		var bankJournalExport = await api.ReadAsync(new Guid("575d62e4-e965-49fd-9a2d-b53bb1ad5434"), testContext.CancellationToken);
		bankJournalExport.EntityName.ShouldBe("MC2IT");
		bankJournalExport.Entries.Count.ShouldBe(5);
		bankJournalExport.Year.ShouldBe(2026);

		var bankJournalEntry = bankJournalExport.Entries.Last();
		bankJournalEntry.AccountingCurrency.ShouldBe("EUR");
		bankJournalEntry.Causale.ShouldBeNull();
		bankJournalEntry.Counterparts.Count.ShouldBe(1);
		bankJournalEntry.Counterparts.First().Name.ShouldStartWith("MC2IT");
		bankJournalEntry.EntryMemo.ShouldBeNull();
		bankJournalEntry.Name.ShouldStartWith("MC2IT");
		bankJournalEntry.OriginalCurrency.ShouldBe("EUR");
	}

	[TestMethod]
	public async Task ReadAll() {
		var list = await api.ReadAllAsync(before: new DateTime(2026, 7, 21, 23, 59, 59, DateTimeKind.Utc), cancellationToken: testContext.CancellationToken);
		list.Items.Count.ShouldBe(3);

		var exportSummary = list.Items.First();
		exportSummary.ExportDateUtc.ShouldBe(new DateTime(2026, 7, 21, 13, 52, 44, 861, DateTimeKind.Utc));
		exportSummary.ExportId.ShouldNotBe(Guid.Empty);
		exportSummary.ExportIndexInYear.ShouldBeGreaterThan(1);
		exportSummary.ExportYear.ShouldBe(2026);
		exportSummary.IndexInYearOfFirstEntryInBankJournal.ShouldBeGreaterThan(1);
		exportSummary.IndexInYearOfLastEntryInBankJournal.ShouldBeGreaterThan(1);
		exportSummary.NumberOfEntries.ShouldBe(222);
	}
}
