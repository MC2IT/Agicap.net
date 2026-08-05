namespace Mc2it.Agicap.Payments;

using System.Net.Http.Json;

/// <summary>
/// Manages the sychronization of beneficiaries of the entity with the specified identifier.
/// </summary>
/// <param name="client">The Agicap API client.</param>
/// <param name="entityId">The entity identifier.</param>
public class BeneficiarySynchronizationApi(Client client, int entityId) {

	/// <summary>
	/// The relative URI of the API endpoint.
	/// </summary>
	private readonly string requestUri = $"payments/v2/entities/{entityId}/Beneficiaries/sync";

	/// <summary>
	/// Starts a bulk synchronization of beneficiaries from the ERP software.
	/// </summary>
	/// <param name="beneficiaries">The beneficiaries to synchronize.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly started synchronization.</returns>
	public Guid Create(IEnumerable<SynchronizedBeneficiary> beneficiaries, CancellationToken cancellationToken = default) =>
		CreateAsync(beneficiaries, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Starts a bulk synchronization of beneficiaries from the ERP software.
	/// </summary>
	/// <param name="beneficiaries">The beneficiaries to synchronize.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly started synchronization.</returns>
	public async Task<Guid> CreateAsync(IEnumerable<SynchronizedBeneficiary> beneficiaries, CancellationToken cancellationToken = default) {
		using var response = await client.PostAsync(requestUri, new { Items = beneficiaries }, cancellationToken: cancellationToken);
		return (await response.Content.ReadFromJsonAsync<SynchronizationIdentifier>(cancellationToken))!.SyncId;
	}

	/// <summary>
	/// Fetches the synchronization report with the specified identifier.
	/// </summary>
	/// <param name="syncId">The identifier of the synchronization report.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The synchronization report with the specified identifier.</returns>
	public BeneficiarySynchronization Read(Guid syncId, CancellationToken cancellationToken = default) =>
		ReadAsync(syncId, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches the synchronization report with the specified identifier.
	/// </summary>
	/// <param name="syncId">The identifier of the synchronization report.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The synchronization report with the specified identifier.</returns>
	public async Task<BeneficiarySynchronization> ReadAsync(Guid syncId, CancellationToken cancellationToken = default) =>
		await client.GetAsync<BeneficiarySynchronization>($"{requestUri}/{syncId}", cancellationToken: cancellationToken);
}
