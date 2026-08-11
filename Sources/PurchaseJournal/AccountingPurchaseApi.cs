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
	/// Fetches the list of entries in the purchase journal.
	/// </summary>
	/// <param name="lastSynchronizationDate">The date of the last synchronization.</param>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="include">An opt-in enrichment selector.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The list of entries in the purchase journal.</returns>
	public PaginatedList<PurchaseJournalEntry> ReadAll(DateTime? lastSynchronizationDate, int? pageNumber = null, int? pageSize = null, string? include = null, CancellationToken cancellationToken = default) =>
		ReadAllAsync(lastSynchronizationDate, pageNumber, pageSize, include, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches the list of entries in the purchase journal.
	/// </summary>
	/// <param name="lastSynchronizationDate">The date of the last synchronization.</param>
	/// <param name="pageNumber">The page number.</param>
	/// <param name="pageSize">The number of elements per page.</param>
	/// <param name="include">An opt-in enrichment selector.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The list of entries in the purchase journal.</returns>
	public async Task<PaginatedList<PurchaseJournalEntry>> ReadAllAsync(DateTime? lastSynchronizationDate, int? pageNumber = null, int? pageSize = null, string? include = null, CancellationToken cancellationToken = default) {
		var queryString = new Dictionary<string, object?> {
			["include"] = include,
			["LastSynchronizationDate"] = lastSynchronizationDate,
			["PageNumber"] = pageNumber,
			["PageSize"] = pageSize
		};

		return await client.GetAsync<PaginatedList<PurchaseJournalEntry>>(requestUri, queryString, cancellationToken);
	}
}
