namespace Mc2it.Agicap.PurchaseJournal;

/// <summary>
/// Manages the accounting purchases of the purchase journal.
/// </summary>
/// <param name="client">The Agicap API client.</param>
/// <param name="entityId">The entity identifier.</param>
public class AccountingPurchaseApi(Client client, int entityId) {

	/// <summary>
	/// The relative URI of the API endpoint.
	/// </summary>
	private readonly string requestUri = $"purchase-journal/v1/entities/{entityId}/accounting-purchases";

	/// <summary>
	/// Reports errors on exported purchase journal entries.
	/// </summary>
	/// <param name="entriesNotImported">The purchase journal entries to mark as not imported.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void MarkAsNotImported(IEnumerable<NotImportedEntry> entriesNotImported, CancellationToken cancellationToken = default) =>
		MarkAsNotImportedAsync(entriesNotImported, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Reports errors on exported purchase journal entries.
	/// </summary>
	/// <param name="entriesNotImported">The purchase journal entries to mark as not imported.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the purchase journal entries have been submitted.</returns>
	public async Task MarkAsNotImportedAsync(IEnumerable<NotImportedEntry> entriesNotImported, CancellationToken cancellationToken = default) =>
		await client.PostAsync($"{requestUri}/exported/mark-as-not-imported", new { EntriesNotImported = entriesNotImported }, cancellationToken: cancellationToken);

	/// <summary>
	/// Fetches the entries of the purchase journal.
	/// </summary>
	/// <param name="lastSynchronizationDate">The date of the last synchronization.</param>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="include">An opt-in enrichment selector.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The entries of the purchase journal.</returns>
	public PaginatedList<PurchaseJournalEntry> ReadAll(DateTime? lastSynchronizationDate, int? pageNumber = null, int? pageSize = null, string? include = null, CancellationToken cancellationToken = default) =>
		ReadAllAsync(lastSynchronizationDate, pageNumber, pageSize, include, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches the entries of the purchase journal.
	/// </summary>
	/// <param name="lastSynchronizationDate">The date of the last synchronization.</param>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="include">An opt-in enrichment selector.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The entries of the purchase journal.</returns>
	public async Task<PaginatedList<PurchaseJournalEntry>> ReadAllAsync(DateTime? lastSynchronizationDate, int? pageNumber = null, int? pageSize = null, string? include = null, CancellationToken cancellationToken = default) {
		var queryString = new Dictionary<string, object?> {
			["Include"] = include,
			["LastSynchronizationDate"] = lastSynchronizationDate?.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"),
			["PageNumber"] = pageNumber,
			["PageSize"] = pageSize
		};

		return await client.GetAsync<PaginatedList<PurchaseJournalEntry>>(requestUri, queryString, cancellationToken);
	}
}
