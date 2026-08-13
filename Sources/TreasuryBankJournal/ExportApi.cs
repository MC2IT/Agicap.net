namespace Mc2it.Agicap.TreasuryBankJournal;

using System.Net.Http.Json;

/// <summary>
/// Manages the exports of the treasury bank journal.
/// </summary>
/// <param name="client">The Agicap API client.</param>
/// <param name="entityId">The entity identifier.</param>
public class ExportApi(Client client, int entityId) {

	/// <summary>
	/// The relative URI of the API endpoint.
	/// </summary>
	private readonly string requestUri = $"treasury-bank-journal/v1/entities/{entityId}";

	/// <summary>
	/// Exports all bank journal entries ready to be exported.
	/// </summary>
	/// <param name="exportId">The identifier of the bank journal export.</param>
	/// <param name="currentExportCounts">Optional export parameters allowing to set where to start.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly started synchronization.</returns>
	public BankJournalExport Create(Guid? exportId = null, BankJournalExportCounts? currentExportCounts = null, CancellationToken cancellationToken = default) =>
		CreateAsync(exportId, currentExportCounts, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Exports all bank journal entries ready to be exported.
	/// </summary>
	/// <param name="exportId">The identifier of the bank journal export.</param>
	/// <param name="currentExportCounts">Optional export parameters allowing to set where to start.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly started synchronization.</returns>
	public async Task<BankJournalExport> CreateAsync(Guid? exportId = null, BankJournalExportCounts? currentExportCounts = null, CancellationToken cancellationToken = default) {
		exportId ??= Guid.CreateVersion7();
		var content = currentExportCounts is null ? null : new { CurrentExportCounts = currentExportCounts };
		using var response = await client.PostAsync($"{requestUri}/exports/{exportId}", content, cancellationToken: cancellationToken);
		return (await response.Content.ReadFromJsonAsync<BankJournalExport>(cancellationToken))!;
	}

	/// <summary>
	/// Notifies Agicap that the specified bank journal entries were successfully imported in the client accounting system.
	/// </summary>
	/// <param name="entriesImported">The bank journal entries to mark as imported.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void MarkAsImported(IEnumerable<ImportedEntry> entriesImported, CancellationToken cancellationToken = default) =>
		MarkAsImportedAsync(entriesImported, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Notifies Agicap that the specified bank journal entries were successfully imported in the client accounting system.
	/// </summary>
	/// <param name="entriesImported">The bank journal entries to mark as imported.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the bank journal entries have been submitted.</returns>
	public async Task MarkAsImportedAsync(IEnumerable<ImportedEntry> entriesImported, CancellationToken cancellationToken = default) =>
		await client.PostAsync($"{requestUri}/exported-bank-journal-entries/mark-as-imported", new { EntriesImported = entriesImported }, cancellationToken: cancellationToken);

	/// <summary>
	/// Notifies Agicap that the specified bank journal entries were not correctly imported in the client accounting system.
	/// </summary>
	/// <param name="entriesNotImported">The bank journal entries to mark as not imported.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void MarkAsNotImported(IEnumerable<NotImportedEntry> entriesNotImported, CancellationToken cancellationToken = default) =>
		MarkAsNotImportedAsync(entriesNotImported, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Notifies Agicap that the specified bank journal entries were not correctly imported in the client accounting system.
	/// </summary>
	/// <param name="entriesNotImported">The bank journal entries to mark as not imported.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the bank journal entries have been submitted.</returns>
	public async Task MarkAsNotImportedAsync(IEnumerable<NotImportedEntry> entriesNotImported, CancellationToken cancellationToken = default) =>
		await client.PostAsync($"{requestUri}/exported-bank-journal-entries/mark-as-not-imported", new { EntriesNotImported = entriesNotImported }, cancellationToken: cancellationToken);

	/// <summary>
	/// Fetches the bank journal export with the specified identifier.
	/// </summary>
	/// <param name="exportId">The identifier of the bank journal export.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The bank journal export with the specified identifier.</returns>
	public BankJournalExport Read(Guid exportId, CancellationToken cancellationToken = default) =>
		ReadAsync(exportId, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches the bank journal export with the specified identifier.
	/// </summary>
	/// <param name="exportId">The identifier of the bank journal export.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The bank journal export with the specified identifier.</returns>
	public async Task<BankJournalExport> ReadAsync(Guid exportId, CancellationToken cancellationToken = default) =>
		await client.GetAsync<BankJournalExport>($"{requestUri}/exports/{exportId}", cancellationToken: cancellationToken);

	/// <summary>
	/// Fetches a list of short summaries of bank journal entries from previous exports.
	/// </summary>
	/// <param name="size">The number of bank journal entries to fetch.</param>
	/// <param name="after">The export start date.</param>
	/// <param name="before">The export end date.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The export list.</returns>
	public CursorPaginatedList<BankJournalExportSummary> ReadAll(int size = 100, DateTime? after = null, DateTime? before = null, CancellationToken cancellationToken = default) =>
		ReadAllAsync(size, after, before, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches a list of short summaries of bank journal entries from previous exports.
	/// </summary>
	/// <param name="size">The number of bank journal entries to fetch.</param>
	/// <param name="after">The export start date.</param>
	/// <param name="before">The export end date.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The export list.</returns>
	public async Task<CursorPaginatedList<BankJournalExportSummary>> ReadAllAsync(int size = 100, DateTime? after = null, DateTime? before = null, CancellationToken cancellationToken = default) {
		var queryString = new Dictionary<string, object?> {
			["after"] = after?.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"),
			["before"] = before?.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"),
			["size"] = size
		};

		return await client.GetAsync<CursorPaginatedList<BankJournalExportSummary>>($"{requestUri}/exports", queryString, cancellationToken);
	}
}
