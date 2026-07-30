namespace Mc2it.Agicap.Payments;

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
	/// <returns>The identifier of the newly created beneficiary.</returns
	public void Create(IEnumerable<Beneficiary> beneficiaries, CancellationToken cancellationToken = default) =>
		CreateAsync(beneficiaries, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Starts a bulk synchronization of beneficiaries from the ERP software.
	/// </summary>
	/// <param name="beneficiaries">The beneficiaries to synchronize.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly created beneficiary.</returns
	public async Task CreateAsync(IEnumerable<Beneficiary> beneficiaries, CancellationToken cancellationToken = default) =>
		await client.PostAsync(requestUri, new NestedList<Beneficiary> { Items = [.. beneficiaries] }, cancellationToken: cancellationToken);

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
