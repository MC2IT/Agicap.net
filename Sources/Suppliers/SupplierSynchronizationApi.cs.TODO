namespace Mc2it.Agicap.Suppliers;

using System.Net.Http.Json;

/// <summary>
/// Manages the sychronization of suppliers of the entity with the specified identifier.
/// </summary>
/// <param name="client">The Agicap API client.</param>
/// <param name="entityId">The entity identifier.</param>
public class SupplierSynchronizationApi(Client client, int entityId) {

	/// <summary>
	/// The relative URI of the API endpoint.
	/// </summary>
	private readonly string requestUri = $"suppliers/v1/entities/{entityId}/sync";

	/// <summary>
	/// Starts a bulk synchronization of suppliers from the ERP software.
	/// </summary>
	/// <param name="suppliers">The suppliers to synchronize.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly started synchronization.</returns>
	public Guid Create(IEnumerable<Supplier> suppliers, CancellationToken cancellationToken = default) =>
		CreateAsync(suppliers, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Starts a bulk synchronization of suppliers from the ERP software.
	/// </summary>
	/// <param name="suppliers">The suppliers to synchronize.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly started synchronization.</returns>
	public async Task<Guid> CreateAsync(IEnumerable<Supplier> suppliers, CancellationToken cancellationToken = default) {
		using var response = await client.PostAsync(requestUri, new { Items = suppliers }, cancellationToken: cancellationToken);
		return (await response.Content.ReadFromJsonAsync<SynchronizationIdentifier>(cancellationToken))!.SyncId;
	}

	/// <summary>
	/// Fetches the synchronization report with the specified identifier.
	/// </summary>
	/// <param name="syncId">The identifier of the synchronization report.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The synchronization report with the specified identifier.</returns>
	public SupplierSynchronization Read(Guid syncId, CancellationToken cancellationToken = default) =>
		ReadAsync(syncId, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches the synchronization report with the specified identifier.
	/// </summary>
	/// <param name="syncId">The identifier of the synchronization report.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The synchronization report with the specified identifier.</returns>
	public async Task<SupplierSynchronization> ReadAsync(Guid syncId, CancellationToken cancellationToken = default) =>
		await client.GetAsync<SupplierSynchronization>($"{requestUri}/{syncId}", cancellationToken: cancellationToken);
}
