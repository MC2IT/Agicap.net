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
	private readonly string requestUri = $"treasury-bank-journal/v1/entities/{entityId}/exports";

	/// <summary>
	/// Exports all bank journal entries ready to be exported.
	/// </summary>
	/// <param name="exportId">The identifier of the bank journal export.</param>
	/// <param name="exportRequest">Optional export parameters allowing to set where to start.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly started synchronization.</returns>
	public BankJournalExport Create(Guid? exportId = null, BankJournalExportRequest? exportRequest = null, CancellationToken cancellationToken = default) =>
		CreateAsync(exportId, exportRequest, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Exports all bank journal entries ready to be exported.
	/// </summary>
	/// <param name="exportId">The identifier of the bank journal export.</param>
	/// <param name="exportRequest">Optional export parameters allowing to set where to start.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly started synchronization.</returns>
	public async Task<BankJournalExport> CreateAsync(Guid? exportId = null, BankJournalExportRequest? exportRequest = null, CancellationToken cancellationToken = default) {
		exportId ??= Guid.CreateVersion7();
		var content = exportRequest is null ? null : new { CurrentExportCounts = exportRequest };
		using var response = await client.PostAsync($"{requestUri}/{exportId}", content, cancellationToken: cancellationToken);
		return (await response.Content.ReadFromJsonAsync<BankJournalExport>(cancellationToken))!;
	}

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
		await client.GetAsync<BankJournalExport>($"{requestUri}/{exportId}", cancellationToken: cancellationToken);

	/// <summary>
	/// Fetches a list of short summaries of bank journal entries from previous exports.
	/// </summary>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The export list.</returns>
	public CursorPaginatedList<BankJournalExportSummary> ReadAll(int size = 100, DateTime? before = null, DateTime? after = null, CancellationToken cancellationToken = default) =>
		ReadAllAsync(size, before, after, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches a list of short summaries of bank journal entries from previous exports.
	/// </summary>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The export list.</returns>
	public async Task<CursorPaginatedList<BankJournalExportSummary>> ReadAllAsync(int size = 100, DateTime? before = null, DateTime? after = null, CancellationToken cancellationToken = default) {
		var queryString = new Dictionary<string, object?> {
			["after"] = after?.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"),
			["before"] = before?.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"),
			["size"] = size
		};

		return await client.GetAsync<CursorPaginatedList<BankJournalExportSummary>>(requestUri, queryString, cancellationToken);
	}
}
